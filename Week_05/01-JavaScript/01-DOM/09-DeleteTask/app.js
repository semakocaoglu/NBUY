'use strict';
let btnAdd = document.getElementById('btnAddNewTask');
let txtTaskName = document.getElementById('txtTaskName');

btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function (event) {
    if (event.key == 'Enter') {
        event.preventDefault();
        btnAdd.click();
    }
});

let gorevListesi = [
    { 'id': 1, 'gorevAdi': 'Görev 1' },
    { 'id': 2, 'gorevAdi': 'Görev 2' },
    { 'id': 3, 'gorevAdi': 'Görev 3' },
    { 'id': 4, 'gorevAdi': 'Görev 4' },
    { 'id': 5, 'gorevAdi': 'Görev 5' },
];

function displayTasks() {
    let ul = document.getElementById('task-list');
    ul.innerHTML = '';
    for (const gorev of gorevListesi) {
        let li = `
        <li class="task list-group-item">
            <div class="form-check">
                <input type="checkbox" id="${gorev.id}" class="form-check-input">
                <label for="${gorev.id}" class="form-check-label">${gorev.gorevAdi}</label>
            </div>
            <div class="dropdown">
                <button class="btn btn-link dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <i class="fa-solid fa-ellipsis"></i>
                </button>
                <ul class="dropdown-menu">
                    <li><a onclick="removeTask(${gorev.id})" class="dropdown-item" href="#"><i class="fa-solid fa-trash-can"></i> Sil</a></li>
                    <li><a class="dropdown-item" href="#"><i class="fa-solid fa-pen"></i> Düzenle</a></li>
                </ul>
                </div>
        </li>
    `;
        ul.insertAdjacentHTML('beforeend', li);
    }
}

function newTask(event) {
    event.preventDefault();
    if (isFull(txtTaskName.value)) {
        gorevListesi.push(
            {
                'id': gorevListesi.length + 1,
                'gorevAdi': ilkHarfiBuyut(txtTaskName.value) //ÖDEV: her kelimenin ilk harfini büyütecek functionı yazınız.
            }
        );
        displayTasks();
    } else {
        alert('Lütfen boş bırakmayınız!');
    }
    txtTaskName.value = '';
    txtTaskName.focus();
};

function isFull(value) {
    if (value.trim() == '') {
        return false;
    }
    return true;
};

function ilkHarfiBuyut(value) {
    let ilkHarf = value[0].toUpperCase();
    let geriKalan = value.slice(1);
    return ilkHarf + geriKalan;
}

function removeTask(id) {
    let deletedId;
    for (const gorevIndex in gorevListesi) {
        if (gorevListesi[gorevIndex].id == id) {
            deletedId = gorevIndex;
        }
    };

    //Alternatif Modern Java Script yöntemleri
    // deletedId = gorevListesi.findIndex(function (gorev) {
    //     return gorev.id == id;
    // });

    // deletedId = gorevListesi.findIndex(gorev => gorev.id==id);

    //Artık gorevListesi dizisinden kaçıncı sıradaki elemanın silineceğini biliyoruz. deletedId'nci sıradaki elemanı sileceğiz.
    gorevListesi.splice(deletedId, 1);
    displayTasks();
}

displayTasks();