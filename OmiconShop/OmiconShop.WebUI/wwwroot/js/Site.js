<script src="/Scripts/jquery-1.4.4.min.js"
    type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $(".RemoveLink").click(function () {
                var product = $(this).attr("data-id");
                if (product != null) {
                    $.post("Basket/RemoveFromBasket", { "productInfo": product },
                        function (data) {
                            $('#row-' + product).fadeOut('slow');
                            $('#cart-status').text("Summary: " + data.BasketTotal + " $");
                        });
                }
            });
        });
</script>

    <script type="text/javascript">
        $(function () {
            $("#emptyBasket").click(function () {
                $.post("Basket/EmptyBasket", { "returnUrl": @Model.RetunrUrl
            },
                function (data) {
                    $('#basketItems').empty();
                    $('#cart-status').text("Summary: " + data.BasketTotal + " $");
                });
        });
    });
</script>

    <script type="text/javascript">
        $(function () {
            $(".uom").change(function () {
                $("#recalculate").show();
                $("#emptyBasket").addClass('disabled');
                $("#returnUrl").addClass('disabled');
                $("#procceedToCheckout").addClass('disabled');
            });
        });
</script>

    <script type="text/javascript">
        $(function () {
            $("#recalculate").click(function () {
                var data = [];

                data.push({ productId: '', quantity: +1 });
                $.post("Basket/RecalculateBasket", { lines: data }
                function (data) {
                        $("#recalculate").hide();
                        $("#emptyBasket").removeClass('disabled');
                        $("#returnUrl").removeClass('disabled');
                        $("#procceedToCheckout").removeClass('disabled');
                        $('#cart-status').text("Summary: " + data.BasketTotal + " $");
                    });
            });
        });
</script>