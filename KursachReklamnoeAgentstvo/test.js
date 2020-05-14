var enjoyhint = new EnjoyHint({})
var a ='Кликните мышью по кнопке!'
var array_enjoy = [
    {
        'click .textboxingg1': 'Vvedite Login'
    },
    {
        'click .textboxingg2': 'Vvedite Password'
    }
];

enjoyhint.set(array_enjoy);
enjoyhint.run();
