const uri = '/api/livros';

function SaveBook() {
    const titulo = document.querySelector('input[name="titulo"]').value;
    const autor = document.querySelector('input[name="autor"]').value;

    const book = {
        Title: titulo,
        Author: autor
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(book)
    })
        .then(response => resonse.json())
        .then(() => {
            titulo.value = '';
            autor.value = '';

        }).catch(error => console.error('Unable to add Item.', error));
}