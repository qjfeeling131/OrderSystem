$(function () {

    var docDateClick = false;
    var docDueDateClick = false;

    var _productListTable = null;
    $(function () {
        $('.rangepicks').daterangepicker({
            "singleDatePicker": true,
            "showDropdowns": true
            //   "autoApply": true,
        });
        $("#orderManager").addClass("active");
        $("#orderManager .treeview-menu").attr("display", "block");
        $("#orderManager .treeview-menu>li").eq(2).addClass("active");

        $("#search").click(function () {
            var searchData = { "cardCode": "", "cardName": "", "itemName": "", "startDate": "", "endDate": "" };
            searchData.cardCode = $("#UserCode").val();
            searchData.cardName = $("#CardName").val();
            searchData.startDate = $("#datetimepicker").val();
            searchData.endDate = $("#docDueDateTimePicker").val();
            searchData.itemName = $("#itemName").val();
            _productTable.ajax.url('GetStatementList?cardCode=' + $("#usercode").val() + '&cardName=' + $("#cardname").val() + '&itemName=' + $("#itemName").val() + '&startDate=' + $("#datetimepicker").val() + '&endDate=' + $("#docduedatetimepicker").val() + '').load();
            //getAsynData("GetCrystalData", searchData, function (json) {
            //    window.open("/Order/ShowRptData", 'mywindow', 'fullscreen=yes, scrollbars=auto');
        });
    });

    var initializeTalbe = function () {
        _productTable = $("#productList").DataTable({
            "language": {
                "sProcessing": "正在加载中......",
                "sLengthMenu": "每页显示 _MENU_ 条记录",
                "sZeroRecords": "对不起，查询不到相关数据！",
                "sEmptyTable": "表中无数据存在！",
                "sInfo": "当前显示 _START_ 到 _END_ 条，共 _TOTAL_ 条记录",
                "sInfoFiltered": "数据表中共为 _MAX_ 条记录",
                "sSearch": "搜索",
                "oPaginate": {
                    "sFirst": "首页",
                    "sPrevious": "上一页",
                    "sNext": "下一页",
                    "sLast": "末页"

                }
            },
            "ajax": {
                "url": "GetStatementList",
                "type": "GET",
                "data": {
                    "cardCode": $("#usercode").val(),
                    "cardName": $("#cardname").val(),
                    "itemName": $("#itemName").val(),
                    "startDate": $("#datetimepicker").val(),
                    "endDate": $("#docduedatetimepicker").val()
                },
                "dataSrc": function (data) {
                    var resultData = [];
                    if (data.Code == "0") {
                        var arr = data.Data;
                        for (var i = 0; i < arr.length; i++) {
                            var tempArr = [];

                            tempArr.push(arr[i].CardCode);
                            tempArr.push(arr[i].CardName);
                            tempArr.push(arr[i].DocDate);
                            tempArr.push(arr[i].DocType);
                            tempArr.push(arr[i].DocNum);
                            tempArr.push(arr[i].ItemName);
                            tempArr.push(arr[i].ItemStandard);
                            tempArr.push(arr[i].Quantity);
                            tempArr.push(arr[i].InvntryUom);
                            tempArr.push(arr[i].PackageQty);
                            tempArr.push(arr[i].PriceAfVAT);
                            tempArr.push(arr[i].GTotal);
                            tempArr.push(arr[i].Paid);
                            tempArr.push(arr[i].Remarks);
                            resultData.push(tempArr);
                        }
                    }
                    return resultData;
                }
            },
            "columnDefs": [{
                "render": function (data, type, row) {
                    var _d = moment(data).clone();
                    return _d.format("YYYY/MM/DD");
                },
                "sType": "FileDate_sort",
                "targets": [2]
            }]
        });
    }

    initializeTalbe();

    function setDateTimePikcerValue(date) {
        if (docDateClick) {
            $("#datetimepicker").val(date);
            docDateClick = false;
        }
        else {
            docDueDateClick = false;
            $("#docDueDateTimePicker").val(date);

        }

    }
    function dateTimePickerClose() {
        //if (docDateClick) {
        //    $("#iframeHtmlControl").hide();
        //    docDateClick = false;
        //}
        //else {
        //    $("#docDueDateiframeHtmlControl").hide();
        //    docDueDateClick = false;
        //}
        $("#docDueDateiframeHtmlControl").hide();
        $("#iframeHtmlControl").hide();
    }
});

