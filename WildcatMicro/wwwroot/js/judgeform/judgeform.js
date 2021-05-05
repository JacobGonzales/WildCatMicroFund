function updateSlider(questionId) {

    const $valueSpan = $(10);
    const $value = $(questionId);
    $valueSpan.html($value.val());
    $value.on('input change', () => {

        $valueSpan.html($value.val());
    });
};