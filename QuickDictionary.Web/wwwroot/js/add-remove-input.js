'use strict';

$(document).on('click', '#btn-add-field', function () {
    var div = $('#translation-manually');

    if ($('.form-group', div).length) {
        var lastFormGroup = $('.form-group', div).last();

        if ($('input:last', lastFormGroup).val().trim() != '') {
            lastFormGroup
                .clone()
                .appendTo(div)
                .find('input.input-with-icon')
                .val('');
        }
    }
    else {
        var html = '';
        html += '<div class="form-group">';
        html += '<label class="input-label">Put translation</label>';
        html += '<div>';
        html += '<input class="form-input input-with-icon" name="translations" type="text" />';
        html += '<span class="glyphicon glyphicon-trash icon-remove-input" title="Delete input field"></span>';
        html += '</div>';
        html += '</div>';
        div.append(html);
    }
});

$(document).on('click', 'span.icon-remove-input', function (event) {
    var formGroup = $(event.target).closest('.form-group');
    formGroup.remove();
});
