// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
setTimeout(function () {
    $('#displayMensagem').fadeOut();
}, 5000);

var actionToDelete;

// Função para exibir o modal de confirmação
function confirmarExclusao(texto, action) {
    actionToDelete = action;

    $('#mensagemConfirm').html(texto);
    $('#confirmModal').modal('show');  // Exibe o modal de confirmação
}

// Ação ao confirmar a exclusão
$('#confirmDeleteBtn').on('click', function () {
    // Redireciona para a ação de exclusão com o clienteId
    window.location.href = actionToDelete;
});