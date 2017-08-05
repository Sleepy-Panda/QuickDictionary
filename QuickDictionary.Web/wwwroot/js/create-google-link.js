'use strict';

$(document).ready(function () {
    setGoogleLink();
});

$(document).on('input', '#Value', function () {
    setGoogleLink();
});

function setGoogleLink() {
    var link = getGoogleLink();
    $('a#google-link').attr('href', link);
}

function getGoogleLink() {
    var link = 'https://translate.google.com?';
    var q = $('#Value').val().trim();
    var sl = languagePair.substring(0, 2);
    var tl = languagePair.substring(3);

    if (q != '') {
        link += 'q=' + q;
    }
    link += '&sl=' + sl;
    link += '&tl=' + tl;

    return link;
}