// ====================
// Multilingualism Module
// ====================
(function (Multilingualism, $, undefined) {

    Dynamite.Multilingualism.AppendUrlHashToLanguageSwitcher = function (jQuerySelector) {

        var updateHash = function (jQuerySelector) {
            if ($(jQuerySelector)) {
                var currentUrl = $(jQuerySelector).attr("href");
                $(jQuerySelector).attr("href", currentUrl.split("#")[0] + window.location.hash);
            }
        }

        $(document).ready(function () { updateHash(jQuerySelector) });
        $(window).on('hashchange', function () { updateHash(jQuerySelector) });
    }

}(Dynamite.Multilingualism = Dynamite.Multilingualism || {}, jQuery));