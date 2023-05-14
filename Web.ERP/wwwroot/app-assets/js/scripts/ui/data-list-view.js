/*=========================================================================================
    File Name: data-list-view.js
    Description: List View
    ----------------------------------------------------------------------------------------
    Item Name: Vuexy  - Vuejs, HTML & Laravel Admin Dashboard Template
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

$(document).ready(function () {
    "use strict";
    // init list view datatable
    var dataListView = $(".data-list-view").DataTable({
        responsive: false,
        //columnDefs: [
        //    {
        //        orderable: true,
        //        targets: 0,
        //        checkboxes: { selectRow: true },
        //    },
        //],
        dom: '<"top top-custom"<"actions action-btns"B><"action-filters"lf>><"clear">rt<"bottom"<"actions">p>',
        // <"dt-action-buttons text-end"B>
        oLanguage: {
            sLengthMenu: "_MENU_",
            sSearch: "",
        },
        aLengthMenu: [
            [4, 10, 25, 100, 1000],
            [4, 10, 25, 100, 1000],
        ],
        select: {
            style: "multi",
        },
        order: [[1, "asc"]],
        bInfo: false,
        rowReorder: {
            selector: "td:nth-child(2)",
        },
        responsive: true,
        pageLength: 4,
        buttons: [
            {
                extend: "collection",
                className: "btn btn-label-primary dropdown-toggle me-2",
                text: `<svg class="icon icon-tabler icon-tabler-file-symlink me-1" width="18" height="18" viewBox="0 0 24 24" stroke-width="1.5" stroke="#7367f0" fill="none" stroke-linecap="round" stroke-linejoin="round">
        <path stroke="none" d="M0 0h24v24H0z" fill="none"/>
        <path d="M4 21v-4a3 3 0 0 1 3 -3h5" />
        <path d="M9 17l3 -3l-3 -3" />
        <path d="M14 3v4a1 1 0 0 0 1 1h4" />
        <path d="M5 11v-6a2 2 0 0 1 2 -2h7l5 5v11a2 2 0 0 1 -2 2h-9.5" />
        </svg> التصدير`,
                buttons: [
                    {
                        extend: "print",
                        text: 'Print <i class="ti ti-printer" ></i>',
                        className: "dropdown-item",
                    },
                    {
                        extend: "csv",
                        text: 'Csv <i class="ti ti-file" ></i>',
                        className: "dropdown-item",
                    },
                    {
                        extend: "excel",
                        text: "Excel",
                        className: "dropdown-item",
                    },
                    {
                        extend: "pdf",
                        text: 'Pdf <i class="ti ti-file-text"></i>',
                        className: "dropdown-item",
                    },
                    {
                        extend: "copy",
                        text: 'Copy <i class="ti ti-copy"></i>',
                        className: "dropdown-item",
                    },
                ],
            },
            //{
            //    text: "<i class='feather icon-plus'></i> حفظ جديد",
            //    action: function () {

            //        $(this).removeClass("btn-secondary")
            //        $(".add-new-data").addClass("show")
            //        $(".overlay-bg").addClass("show")
            //        $("#data-name, #data-price").val("")
            //        $("#data-category, #data-status").prop("selectedIndex", 0)
            //        $(this).click(Reset())
            //    },
            //    className: " btn btn-info add-new" // btn btn-outline-primary
            //}
        ],
        initComplete: function (settings, json) {
            $(".dt-buttons .btn").removeClass("btn-secondary")
        }
    });

    //dataListView.on("draw.dt", function () {
    //    setTimeout(function () {
    //        if (navigator.userAgent.indexOf("Mac OS X") != -1) {
    //            $(".dt-checkboxes-cell input, .dt-checkboxes").addClass("mac-checkbox");
    //        }
    //    }, 50);
    //});
    // To append actions dropdown before add new button
    var actionDropdown = $(".actions-dropodown");
    actionDropdown.insertBefore($(".top .actions .dt-buttons"));

    // Scrollbar
    if ($(".data-items").length > 0) {
        new PerfectScrollbar(".data-items", { wheelPropagation: false });
    }

    // Close sidebar
    $(".hide-data-sidebar, .cancel-data-btn, .overlay-bg").on(
        "click",
        function () {
            $(".add-new-data").removeClass("show");
            $(".overlay-bg").removeClass("show");
            $("#data-name, #data-price").val("");
            $("#data-category, #data-status").prop("selectedIndex", 0);
        }
    );

    // On Edit
    $(".action-edit").on("click", function (e) {
        e.stopPropagation();
        //$("#data-name").val("Altec Lansing - Bluetooth Speaker");
        //$("#data-price").val("$99");
        $(".add-new-data").addClass("show");
        $(".overlay-bg").addClass("show");
    });

    // On Delete
    //$(".action-delete").on("click", function (e) {
    //    e.stopPropagation();
    //    /*$(this).closest("td").parent("tr").fadeOut();*/
    //});

    // On Add
    $(".action-add").on("click", function (e) {
        e.stopPropagation();
        $(".add-new-data").addClass("show");
        $(".overlay-bg").addClass("show");
        $("#data-name, #data-price").val("");
        $("#data-category, #data-status").prop("selectedIndex", 0);
    });
    // dropzone init
    Dropzone.options.dataListUpload = {
        complete: function (files) {
            var _this = this;
            // checks files in class dropzone and remove that files
            $(".hide-data-sidebar, .cancel-data-btn, .actions .dt-buttons").on(
                "click",
                function () {
                    $(".dropzone")[0].dropzone.files.forEach(function (file) {
                        file.previewElement.remove();
                    });
                    $(".dropzone").removeClass("dz-started");
                }
            );
        },
    };
 Dropzone.options.dataListUpload.complete();

    // mac chrome checkbox fix
    if (navigator.userAgent.indexOf("Mac OS X") != -1) {
        $(".dt-checkboxes-cell input, .dt-checkboxes").addClass("mac-checkbox");
    }
});
