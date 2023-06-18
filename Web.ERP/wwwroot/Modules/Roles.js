$(document).ready(() => {
    $('#selectAll').on('click', () => {
        let Selected = document.getElementsByName("Selected");
        if (selectAll.checked == true) {
            for (let i = 0; i < Selected.length; i++) {
                Selected[i].checked = true;
            }
        }
        else {
            for (let i = 0; i < Selected.length; i++) {
                Selected[i].checked = false;
            }
        }
    });

    //Methode Deleted
    onDelete = (id) => {
        bootbox.confirm({
            message: 'هل انت متاكد من حذف هذه المجموعة؟',
            buttons: {
                confirm: {
                    label: 'نعم',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'الغاء',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result == true) {
                    location.href = '/Accounts/DeleteRole/' + id;
                }
            }
        });

        // 
    }


    //Method of delete all jquery
    //3yza submit form 
    $('#btn-DeleteAll').on('click', () => {
        bootbox.confirm({
            message: 'هل انت متاكد من حذف كل المحدد؟',
            buttons: {
                confirm: {
                    label: 'نعم',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'الغاء',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result == true) {
                    $('#Submit-Form').submit();
                }
            }
        });


    });

    //Methode Edit 
    onEdit = (index) => {
        let role = roles[index];
        
        $('#roleId').val(role.roleId);
        $('#roleName').val(role.roleName);

    };
    //Methode Rese

    $('.Reset').on('click', () => {
        $('#roleId').val('');
        $('#roleName').val('');
    });
});
