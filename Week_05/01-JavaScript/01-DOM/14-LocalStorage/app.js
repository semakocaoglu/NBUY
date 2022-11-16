'use strict';
const btnAdd = document.getElementById('btnAddNewTask');
const txtTaskName = document.getElementById('txtTaskName');
const btnClear = document.getElementById('btnClear');
const filters = document.querySelectorAll('.filters span');

let isEditMode = false;
let editedId;
btnAdd.addEventListener('click', newTask);
txtTaskName.addEventListener('keypress', function (event) {
    if (event.key == 'Enter') {
        event.preventDefault();
        btnAdd.click();
    }
});
btnClear.addEventListener('click', clearAll);
for (const span of filters) {
    span.addEventListener('click', function () {
        document.querySelector('span.active').classList.remove('active');
        span.classList.add('active');
        displayTasks(span.id);
    });
};
let gorevListesi = [];
if (localStorage.getItem('gorevListesi') != null) {
    gorevListesi = JSON.parse(localStorage.getItem('gorevListesi'));
}
let taskBox = document.getElementById('task-box');
function displayTasks(filter) {
    let ul = document.getElementById('task-list');
    ul.innerHTML = '';
    if (gorevListesi.length == 0) {
        ul.innerHTML = '<span class="alert alert-danger mb-0">Görev Listeniz boş!</span>';
    }
    for (const gorev of gorevListesi) {
        let completed = gorev.durum == 'completed' ? 'checked' : '';
        if (filter == gorev.durum || filter == 'all') {
            let li = `
                <li class="task list-group-item">
                    <div class="form-check">
                        <input onclick="updateStatus(this)" type="checkbox" id="${gorev.id}" class="form-check-input" ${completed}>
                        <label for="${gorev.id}" class="form-check-label ${completed}">${gorev.gorevAdi}</label>
                    </div>
                    <div class="dropdown">
                        <button class="btn btn-link dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            <i class="fa-solid fa-ellipsis"></i>
                        </button>
                        <ul class="dropdown-menu">
                            <li><a onclick="removeTask(${gorev.id})" class="dropdown-item" href="#"><i class="fa-solid fa-trash-can"></i> Sil</a></li>
                            <li><a onclick="editTask(${gorev.id},'${gorev.gorevAdi}')" class="dropdown-item" href="#"><i class="fa-solid fa-pen"></i> Düzenle</a></li>
                        </ul>
                        </div>
                </li>`;
            ul.insertAdjacentHTML('beforeend', li);
        };
    };
}

function newTask(event) {
    event.preventDefault();
    if (isFull(txtTaskName.value)) {
        if (!isEditMode) {
            //Yeni kayıt işlemleri
            let id;
            if (gorevListesi.length == 0) {
                id = 1;
            } else {
                id = gorevListesi[gorevListesi.length - 1].id + 1;
            }
            gorevListesi.push(
                {
                    'id': id,
                    'gorevAdi': ilkHarfiBuyut(txtTaskName.value),
                    'durum': 'pending'
                }
            );
        } else {
            //Güncelleme işlemleri
            for (const gorev of gorevListesi) {
                if (gorev.id == editedId) {
                    gorev.gorevAdi = ilkHarfiBuyut(txtTaskName.value);
                    isEditMode = false;
                    btnAdd.innerText = 'Ekle';
                    taskBox.style.display = 'block';
                    break;
                }
            }
        }
    } else {
        alert('Lütfen boş bırakmayınız!');
    }
    txtTaskName.value = '';
    displayTasks(document.querySelector('span.active').id);
    txtTaskName.focus();
    saveLocal();
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
    gorevListesi.splice(deletedId, 1);
    displayTasks(document.querySelector('span.active').id);
    saveLocal();
}

function editTask(id, gorevAdi) {
    editedId = id;
    isEditMode = true;
    txtTaskName.value = gorevAdi;
    txtTaskName.focus();
    btnAdd.innerText = 'Kaydet';
    // taskBox.style.visibility='hidden';
    taskBox.style.display = 'none';
}

function clearAll() {
    let cevap = confirm('Tüm görevler silinecek!');
    if (cevap) {
        gorevListesi.splice(0);
        displayTasks('all');
        saveLocal();
    }
}

function updateStatus(selectedTask) {
    // console.log(selectedTask.parentElement.lastElementChild);
    // console.log(selectedTask.nextElementSibling);
    let label = selectedTask.nextElementSibling;
    let durum;
    if (selectedTask.checked) {
        label.classList.add('checked');
        durum = 'completed';
    } else {
        label.classList.remove('checked');
        durum = 'pending';
    };
    for (const gorev of gorevListesi) {
        if (gorev.id == selectedTask.id) {
            gorev.durum = durum;
        }
    }
    displayTasks(document.querySelector('span.active').id);
    saveLocal();
}

function saveLocal() {
    localStorage.setItem('gorevListesi', JSON.stringify(gorevListesi));
}

displayTasks('all');
