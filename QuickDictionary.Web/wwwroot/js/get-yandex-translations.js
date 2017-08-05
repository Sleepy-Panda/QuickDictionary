$(document).on('focusout', '#Value', function () {
    var targetText = $('#Value').val().trim();

    if (targetText == '') {
        showCannotTranslate();
        return;
    }

    hideCannotTranslate();

    var translations = [];
    var trLink = 'https://translate.yandex.net/api/v1.5/tr.json/translate?key=trnsl.1.1.20170213T172041Z.188b671735d113e7.b44d78d5c904d7a51611c185121e7df8671cd00c&text=' + targetText + '&lang=' + languagePair;
    var dLink = 'https://dictionary.yandex.net/api/v1/dicservice.json/lookup?key=dict.1.1.20170213T181444Z.08ee015e9d8d82f7.eda86d019b0feff6a7265faf46dc6d9aee180f55&text=' + targetText + '&lang=' + languagePair;

    $.ajax({
        type: 'GET',
        url: trLink,
        success: function (response) {
            response.text.forEach(
                function (item) {
                    translations.push(item.toLowerCase());
                }
            );

            $.ajax({
                type: 'GET',
                url: dLink,
                success: function (response) {
                    response.def.forEach(
                        function (item) {
                            item.tr.forEach(
                                function (item) {
                                    translations.push(item.text.toLowerCase());
                                }
                            );
                        }
                    );

                    if (translations.length > 0) {
                        translations = translations.filter(onlyUniqueItems);

                        translations.forEach(function (item) {
                            $('#translation-auto').append('<div class="checkbox"><label><input type="checkbox" name="translations" value="' + item + '"/>' + item + '</label></div>');
                        });
                    }
                    else {
                        showCannotTranslate();
                    }
                },
                error: function () {
                    showCannotTranslate();
                },
            });
        },
        error: function () {
            showCannotTranslate();
        }
    });
});

function onlyUniqueItems(value, index, self) {
    return self.indexOf(value) === index;
}

function showCannotTranslate() {
    $('#translation-auto').empty();
    $('#no-translations-found').removeClass('hidden');
}

function hideCannotTranslate() {
    $('#translation-auto').empty();
    $('#no-translations-found').not('.hidden').addClass('hidden');
}