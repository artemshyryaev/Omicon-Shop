$(function () {
    $(".link-remove").click(function (e) {
        var $element = e.target;
        var product = $element.attr("data-id");
        if (product !== null) {
            $.post("Basket/RemoveFromBasket", { "productInfo": product },
                function (data) {
                    $('.row-' + product).remove();
                    $('.cart-status').text("Summary: " + data.BasketTotal + " $");
                    if (data.Count <= 0) {
                        $(".btn-procceedToCheckout").addClass('disabled');
                        $(".btn-emptyBasket").hide();
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
    $(".qty").change(function (e) {
        $(".btn-emptyBasket").addClass('disabled');
        $(".btn-returnUrl").addClass('disabled');
        $(".btn-procceedToCheckout").addClass('disabled');

        var $element = $(e.target);
        var productId = $element.attr("data-product-id");
        var productUOM = $element.attr("data-product-uom");
        var sQty = $element.val();
        var fQty = parseFloat(sQty);
        var sPrice = $element.attr("data-product-price");
        var fPrice = parseFloat(sPrice).toFixed(2);
        $.post("Basket/RecalculateBasket", { "productId": productId, "productUOM": productUOM, "qty": sQty },
            function (data) {
                $(".total-" + productId + "-" + productUOM).text((fQty * fPrice) + " $");
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

$(function () {
    $(".link-delete").click(function (e) {
        var $element = $(e.target);
        var productId = $element.attr("data-id");
        if (productId !== null) {
            $.post("DeleteProduct", { "productId": productId },
                function () {
                    $('.row-' + productId).remove();
                });
        }
    });
});