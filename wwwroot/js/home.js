function OtherPage() {
    const crud = document.querySelector('input[name="select_crud"]:checked').value;
    switch (crud) {
        case 'Cadastrar':
            window.location.href = "/Create/index.html";
            break;
        case 'Papayas':
            console.log('Mangoes and papayas are $2.79 a pound.');
            break;
        default:
            console.log(`Sorry, we are out.`);
    }

    
}