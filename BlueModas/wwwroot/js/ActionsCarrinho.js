$(document).ready(function () {

    admBtnContinua(true);

    var produto = new Produto(null, null, null, null, null, null);
    $(".qtd-produto").focus(function () {
        produto.qtdAntiga = $(this).get(0).value;
    })
    $(".qtd-produto").change(function () {
        produto.campoQtd = $(this).get(0);
        produto.id = parseInt($(this).parent().find("input")[0].value);
        produto.qtdNova = parseInt(produto.campoQtd.value);
        produto.campoValor = $(this).parent().parent().find(".price").get(0);
        produto.campoQtdMax = $(this).parent().find(".qtd-max").get(0);
        produto.valor = parseFloat($(this).parent().find("input")[1].value.replace(',', '.'));

        produto.campoValor.innerText = AlteraMoedaBr(produto.qtdNova * produto.valor);

        AlteraCampoTotal();
        CalculaPagamentoTotal();
        AjaxAlteraCookieCarrinhoProduto(produto);
    })
})

function AlteraMoedaBr(valor) {
    return "R$ " + valor.toFixed(2).replace('.', ',');
}

function AlteraCampoTotal() {
    var campoValores = $(".price");
    var somaValores = 0;
    var campoValorTotal = $(".valor-soma").get(0);
    for (var i = 0; i < campoValores.length; i++) {
        var Valor = parseFloat(campoValores[i].innerText.replace(/[R$ ]/g, "").replace(',', '.'));
        somaValores += Valor;
    }
    campoValorTotal.innerText = AlteraMoedaBr(somaValores);
}

function CalculaPagamentoTotal() {
    var campoValorTotal = $(".valor-soma").get(0);
    var campoPagamentoTotal = $(".valor-total").get(0);

    var ValorProdutos = parseFloat(campoValorTotal.innerText.replace(/[R$ ]/g, "").replace(',', '.'));

    campoPagamentoTotal.innerText = AlteraMoedaBr(ValorProdutos);
}



function admBtnContinua(habilitar) {
    var btnContinua = $(".pedido-continuar");

    if (habilitar) {
        if (btnContinua.hasClass("disabled"))
            btnContinua.removeClass("disabled");
    }
    else {
        if (!btnContinua.hasClass("disabled"))
            btnContinua.addClass("disabled");
    }
}


function AjaxAlteraCookieCarrinhoProduto(produto) {

    $.ajax({
        type: "GET",
        url: "/CarrinhoCompra/AlterarQuantidade?id=" + produto.id + "&quantidade=" + produto.qtdNova,
        error: function (data) {

            //ROLLBACK
            produto.campoQtd.value = produto.qtdAntiga;
            produto.campoQtd.max = data.responseJSON.qtdMax;
            produto.campoQtdMax.innerText = data.responseJSON.qtdMax + " un.";
            produto.qtdNova = produto.qtdAntiga;
            produto.campoValor.innerText = AlteraMoedaBr(produto.qtdNova * produto.valor);

            AlteraCampoTotal();
        },
        success: function () {
            admBtnContinua(false);
        }
    })
}


function Produto(id, qtdNova, qtdAntiga, campoValor, valor, campoQtd, campoQtdMax) {
    this.id = id;
    this.qtdNova = qtdNova;
    this.qtdAntiga = qtdAntiga;
    this.campoValor = campoValor;
    this.valor = valor;
    this.campoQtd = campoQtd;
    this.campoQtdMax = campoQtdMax;
}