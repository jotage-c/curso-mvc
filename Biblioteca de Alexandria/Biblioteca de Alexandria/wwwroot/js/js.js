window.onload = function() {
    textFit(document.getElementsByClassName('card-title'), {
        multiLine: true,
        alignVert: false,
        maxFontSize: 20,
        minFontSize: 10
    });
};