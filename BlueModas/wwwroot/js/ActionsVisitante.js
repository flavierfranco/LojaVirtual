$(document).ready(function () {
   
    $("#order-form").change(function () {
        var pesquisa = "";
        var ordem = $(this).val();
        var pagina = 1;

        var QueryString = new URLSearchParams(window.location.search);
        if (QueryString.has("pesquisa")) {
            pesquisa = QueryString.get("pesquisa");
        }

        var protocol = window.location.protocol;
        var host = window.location.hostname;
        var URL = protocol + "//" + host + ":" + window.location.port + window.location.pathname + "?pagina=" + pagina + "&pesquisa=" + pesquisa + "&ordem=" + ordem + "#titlePage";

        window.location.replace(URL);
    });
    $(".item-gallery").click(function () {
        var imgClicada = $(this).find("img").get(0);
        var ancora = $('.img-big-wrap').find('div').find('a').get(0);
        var img = $('.img-big-wrap').find('div').find('img').get(0);

        ancora.href = imgClicada.src;
        img.src = imgClicada.src;

    });
    $(".btn-adiciona").click(function (event) {
        event.preventDefault();
        var produtoId = $(this).parent().find(".produto-id").val();
        $.ajax({
            method: "GET",
            url: "/carrinhocompra/adicionaritem?id=" + produtoId,
            success: function () {

            } ,
            error: function (data) {
                window.location = "#";
                window.scrollBy(0, 200);
            }
        })
    })
});
