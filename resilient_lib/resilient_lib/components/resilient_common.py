# -*- coding: utf-8 -*-
# (c) Copyright IBM Corp. 2018. All Rights Reserved.
# pragma pylint: disable=unused-argument, no-self-use

import datetime
from bs4 import BeautifulSoup
from six import string_types
try:
    from HTMLParser import HTMLParser as htmlparser
except:
    import html.parser as htmlparser


INCIDENT_FRAGMENT = '#incidents'
PAYLOAD_VERSION = "1.0"

def build_incident_url(url, incidentId):
    """
    build the url to link to an resilient incident
    :param url: base url
    :param incidentId:
    :return: full url
    """
    return '/'.join([url, INCIDENT_FRAGMENT, str(incidentId)])

def build_resilient_url(host, port):
    """
    build basic url to resilient instance
    :param host: host name
    :param port: port
    :return: base url
    """
    if host.lower().startswith("http"):
        return "{0}:{1}".format(host, port)

    return "https://{0}:{1}".format(host, port)

def clean_html(html_fragment):
    """
    Resilient textarea fields return html fragments. This routine will remove the html and insert any code within <div></div>
    with a linefeed
    :param html_fragment:
    :return: cleaned up code
    """

    if not html_fragment or not isinstance(html_fragment, string_types):
        return html_fragment

    s = BeautifulSoup(unescape(html_fragment), "html.parser")

    return ' '.join(s.strings)

def unescape(data):
    """ Return unescaped data such as &gt; -> >, &quot -> ', etc. """
    #try:
    if data is None:
        return None

    h = htmlparser()
    return h.unescape(data)


def validate_fields(field_list, kwargs):
    """
    ensure required fields are present. Throw ValueError if not
    :param field_list:
    :param kwargs:
    :return: no return
    """
    for field in field_list:
        if field not in kwargs or kwargs.get(field) == '':
            raise ValueError('Required field is missing or empty: '+field)

def build_function_result(success, reason, result, metrics_json, inputs_json):
    """
    build a standard payload for functions
    :param success:
    :param reason:
    :param result:
    :param metrics_json:
    :param inputs_json:
    :return:
    """
    payload = {
                "version": PAYLOAD_VERSION,
                "success": success,
                "reason": reason,
                "content": result,
                "inputs": inputs_json,
                "metrics": metrics_json
              }

    return payload

def get_file_attachment(res_client, incident_id, artifact_id, task_id, attachment_id):
    """ call the Resilient REST API to get the attachment or artifact data"""

    if incident_id and artifact_id:
        data_uri = "/incidents/{}/artifacts/{}/contents".format(incident_id, artifact_id)
    elif attachment_id:
        if task_id:
            data_uri = "/tasks/{}/attachments/{}/contents".format(task_id, attachment_id)
        elif incident_id:
            data_uri = "/incidents/{}/attachments/{}/contents".format(incident_id, attachment_id)
        else:
            raise ValueError("task_id or incident_id must be specified with attachment")
    else:
        raise ValueError("artifact or attachment or incident id must be specified")

    # Get the data
    return res_client.get_content(data_uri)

def readable_datetime(timestamp, milliseconds=True, rtn_format='%Y-%m-%dT%H:%M:%SZ'):
    """
    convert an epoch timestamp to a string using a format
    :param timestamp:
    :param milliseconds: True = epoch in
    :param rtn_format: format of resulant string
    :return: string representation of timestamp
    """
    if milliseconds:
        ts = int(timestamp/1000)
    else:
        ts = timestamp

    return datetime.datetime.utcfromtimestamp(ts).strftime(rtn_format)

def parse_bool(value):
    """Represents value as boolean.
    :param value:
    :rtype: bool
    """
    value = str(value).lower()
    return value in ('1', 'true', 'yes')
