$(function () {
    $(".link-remove").click(function () {
        var product = $(".link-remove").attr("data-id");
        if (product !== null) {
            $.post("Basket/RemoveFromBasket", { "productInfo": product },
                function (data) {
                    $('.row-' + product).fadeOut('slow');
                    $('.cart-status').text("Summary: " + data.BasketTotal + " $");
                    if (data.Count <= 0) {
                        $(".btn-procceedToCheckout").addClass('disabled');
                        $(".btn-emptyBasket").hide();
                        $(".btn-recalculate").hide();
                    }
                });
        }
    });
});

$(function () {
    $(".btn-emptyBasket").click(function () {
        var retunrUrl = $(".btn-returnUrl").attr("href");
        $.post("Basket/EmptyBasket", { "returnUrl": retunrUrl },
            function (data) {
                $('.basketItems').empty();
                $('.cart-status').text("Summary: " + data.BasketTotal + " $");
                $(".btn-emptyBasket").hide();
                $(".btn-procceedToCheckout").addClass('disabled');
            });
    });
});

$(function () {
    $(".uom").change(function () {
        $(".btn-recalculate").show();
        $(".btn-emptyBasket").addClass('disabled');
        $(".btn-returnUrl").addClass('disabled');
        $(".btn-procceedToCheckout").addClass('disabled');
    });
});

$(function () {
    $(".btn-recalculate").click(function () {
        var data = [];
        data.push({ productId: '', quantity: +1 });
        $.post("Basket/RecalculateBasket", { lines: data },
            function (data) {
                $(".btn-recalculate").hide();
                $(".btn-emptyBasket").removeClass('disabled');
                $(".btn-returnUrl").removeClass('disabled');
                $(".btn-procceedToCheckout").removeClass('disabled');
                $('.cart-status').text("Summary: " + data.BasketTotal + " $");
            });
    });
});

$(function () {
    var lines = $(".lines-count").attr("value");
    if (lines <= 0) {
        $(".btn-recalculate").hide();
        $(".btn-emptyBasket").hide();
        $(".btn-procceedToCheckout").addClass('disabled');
    }
});

$(function () {
    var returnUrl = $(".btn-returnUrl").attr("href");
    if (typeof returnUrl === 'undefined') {
        $(".btn-returnUrl").addClass('disabled');
    }
});