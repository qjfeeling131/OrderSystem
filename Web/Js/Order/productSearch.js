$(function () {
    var self = this;
    var companyFlag = false;
    var companyChangeStatus = false;
    var companyValue;
    var categoryValue;
    var subCategoryValue;
    var categoryChangeStatus = false;
    var subcategoryChangeStatus = false;
    var product = { itemCode: "", itemName: "", itemprice: "0", itemStandard: "", itemUnit: "", itemquantity: "1", itemcustomerprice: "0", iteminnerprice: "0" };
    var _productTable = null;

    $("#company").change(function () { selectChange("company"); });
    $("#category").change(function () { selectChange("category"); });
    $("#sub-category").change(function () { selectChange("sub-category"); });
    $("#product").change(function () { selectChange("product") });

    function selectChange(selectObj) {
        var selectText = $("#" + selectObj + "").find("option:selected").text();
        //alert(selectText);
        //获取下拉框选中项的value属性值
        var selectValue = $("#" + selectObj + "").val();
        if (selectObj.indexOf("company") >= 0) {
            companyValue = selectValue;
            companyChangeStatus = true;
        }
        if (selectObj == "category") {
            categoryValue = selectValue;
            categoryChangeStatus = true;
        }
        if (selectObj.indexOf("sub") >= 0) {
            subCategoryValue = selectValue;
            subcategoryChangeStatus = true;
            _productTable.ajax.url('GetProducts?key=' + subCategoryValue + '&cardCode=' + $("#UserCode").val() + '').load();
        }
        if (selectObj.indexOf("product") >= 0) {
            product.itemCode = $("#product").find("option:selected").attr("itemCode");
            product.itemName = $("#product").find("option:selected").attr("itemName");
            product.itemStandard = $("#product").find("option:selected").attr("itemStandard");
            product.itemUnit = $("#product").find("option:selected").attr("itemUnit");
            product.itemcustomerprice = $("#product").find("option:selected").attr("itemCustomerPrice");
        }
        //alert(selectValue);
        console.log(companyValue);
        //获取下拉框选中项的index属性值
        var selectIndex = $("#" + selectObj + "").get(0).selectedIndex;
        //alert(selectIndex);5
        ////获取下拉框最大的index属性值
        var selectMaxIndex = $("#" + selectObj + " option:last").attr("index");
        //alert(selectMaxIndex);


    };

    $("#company").mouseenter(function () {
        if (!companyFlag) {
            $("#company").empty();
            getAsynData("ProductSearch", " " + "&" + 0, function (json) {
                $("#company").append("<option >-------请选择-------</option>");
                for (var rowIndex = 0; rowIndex < json.Data.length; rowIndex++) {
                    $("#company").append("<option value=" + json.Data[rowIndex].CatalogCode + ">" + json.Data[rowIndex].CatalogCode + "-" + json.Data[rowIndex].CatalogName + "</option>");
                }
                companyFlag = true;
                initializeTalbe();
            });
        }
    });

    $("#category").mouseenter(function () {
        if (companyChangeStatus) {
            if (companyValue == "" || companyValue == "undefined" || companyValue == null) {
                alertInfo("公司选择错误", "公司尚未选择");
                return;
            }
            $("#category").empty();
            var searchData = { "key": "", "flag": "" };
            searchData.key = companyValue;
            searchData.flag = 1;
            $("#category").append("<option >-------请选择-------</option>");
            getAsynData("ProductSearch", searchData, function (json) {
                for (var rowIndex = 0; rowIndex < json.Data.length; rowIndex++) {
                    $("#category").append("<option value=" + json.Data[rowIndex].CatalogCode + ">" + json.Data[rowIndex].CatalogCode + "-" + json.Data[rowIndex].CatalogName + "</option>");
                }
                companyChangeStatus = false;
            });
        }
    });

    $("#sub-category").mouseenter(function () {
        if (categoryChangeStatus) {
            if (categoryValue == "" || categoryValue == "undefined" || categoryValue == null) {
                alertInfo("类型选择错误", "类别尚未选择");
                return;
            }
            $("#sub-category").empty();
            var searchData = { "key": "", "flag": "" };
            searchData.key = categoryValue;
            searchData.flag = 1;
            $("#sub-category").append("<option >-------请选择-------</option>");
            getAsynData("ProductSearch", searchData, function (json) {
                for (var rowIndex = 0; rowIndex < json.Data.length; rowIndex++) {
                    $("#sub-category").append("<option value=" + json.Data[rowIndex].CatalogCode + ">" + json.Data[rowIndex].CatalogCode + "-" + json.Data[rowIndex].CatalogName + "</option>");
                }
                categoryChangeStatus = false;
            });
        }
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
                "url": "GetProducts",
                "type": "GET",
                "data": {
                    "key": subCategoryValue,
                    "cardCode": $("#UserCode").val()
                },
                "dataSrc": function (data) {
                    var resultData = [];
                    if (data.Code == "0") {
                        var arr = data.Data;
                        for (var i = 0; i < arr.length; i++) {
                            var tempArr = [];

                            tempArr.push(arr[i].ItemCode);
                            tempArr.push(arr[i].ItemName);
                            tempArr.push(arr[i].ItemStandard);
                            tempArr.push(arr[i].ItemUnit);
                            tempArr.push(arr[i].GroupAPrice);
                            resultData.push(tempArr);
                        }
                    }
                    return resultData;
                }
            }
            //"columnDefs": [
            //        {
            //            "targets": [3],
            //            "visible": false
            //        }
            //]
        });

        $('#productList tbody').on('click', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                product.itemCode = $(this).children().first().text();
                product.itemName = $(this).children().eq(1).text();
                product.itemStandard = $(this).children().eq(2).text();
                product.itemUnit = $(this).children().eq(3).text();
                product.itemcustomerprice = $(this).children().eq(4).text();
            }
            else {
                $('#productList').DataTable().$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                product.itemCode = $(this).children().first().text();
                product.itemName = $(this).children().eq(1).text();
                product.itemStandard = $(this).children().eq(2).text();
                product.itemUnit = $(this).children().eq(3).text();
                product.itemcustomerprice = $(this).children().eq(4).text();
            }
        });

        $('#productList tbody').on('dblclick', 'tr', function () {
            if ($(this).hasClass('selected')) {
                $(this).removeClass('selected');
                product.itemCode = $(this).children().first().text();
                product.itemName = $(this).children().eq(1).text();
                product.itemStandard = $(this).children().eq(2).text();
                product.itemUnit = $(this).children().eq(3).text();
                product.itemcustomerprice = $(this).children().eq(4).text();
                $("#comfirm_code").click();
            }
            else {
                $('#productList').DataTable().$('tr.selected').removeClass('selected');
                $(this).addClass('selected');
                product.itemCode = $(this).children().first().text();
                product.itemName = $(this).children().eq(1).text();
                product.itemStandard = $(this).children().eq(2).text();
                product.itemUnit = $(this).children().eq(3).text();
                product.itemcustomerprice = $(this).children().eq(4).text();
                $("#comfirm_code").click();
            }
        });
    }

    $("#product").mouseenter(function () {
        if (subcategoryChangeStatus) {
            if (subCategoryValue == "" || subCategoryValue == "undefined" || subCategoryValue == null) {
                alertInfo("类型选择错误", "类别尚未选择");
                return;
            }
            $("#product").empty();
            var searchData = { "key": "", "cardCode": "" };
            searchData.key = subCategoryValue;
            searchData.cardCode = $("#UserCode").val();
            $("#product").append("<option >-------请选择-------</option>");
            getAsynData("GetProducts", searchData, function (json) {
                for (var rowIndex = 0; rowIndex < json.Data.length; rowIndex++) {
                    $("#product").append("<option itemcode=" + json.Data[rowIndex].ItemCode + " itemName=" + json.Data[rowIndex].ItemName + " itemName=" + json.Data[rowIndex].ItemName + " itemStandard=" + json.Data[rowIndex].ItemStandard + " itemUnit=" + json.Data[rowIndex].ItemUnit + " itemCustomerPrice=" + json.Data[rowIndex].GroupAPrice + ">[" + json.Data[rowIndex].ItemCode + "] -   [" + json.Data[rowIndex].ItemName + "-" + json.Data[rowIndex].ItemStandard + "] -- [" + json.Data[rowIndex].GroupAPrice + "]</option>");
                }
                subcategoryChangeStatus = false;
            });
        }
    });

    $("#comfirm_code").click(function () {
        if (product.itemCode == "" || product.itemCode == "undefined" || product.itemCode == null) {
            alertInfo("产品选择错误", "请选择产品");
            return;
        }
        $("#itemcode").val(product.itemCode);
        $("#itemname").val(product.itemName);
        $("#itemprice").val(product.itemprice);
        $("#itemStandard").val(product.itemStandard);
        $("#itemUnit").val(product.itemUnit);
        $("#itemquantity").val(product.itemquantity);
        if ($(product.itemcustomerprice) == null || isNullorEmptyString(product.itemcustomerprice)) {
            $("#itemcustomerprice").val("0");
        }
        else {
            $("#itemcustomerprice").val(product.itemcustomerprice);
        }
        $("#iteminnerprice").val(product.itemprice);
    });

    $("#search").click(function () {
        var searchKey = $("#searchKey").val();
        if (searchKey.length >= 2) {
            var searchData = { "searchKey": "" };
            searchData.searchKey = searchKey;
            _productTable.ajax.url('GetProductList?searchKey=' + searchKey + '&cardCode=""').load();
            //getAsynData("FuzzySearchProduct", searchData, function (json) {
            //    for (var rowIndex = 0; rowIndex < json.Data.length; rowIndex++) {
            //        $("#product").append("<option itemcode=" + json.Data[rowIndex].ItemCode + " itemName=" + json.Data[rowIndex].ItemName + " itemName=" + json.Data[rowIndex].ItemName + " itemStandard=" + json.Data[rowIndex].ItemStandard + " itemUnit=" + json.Data[rowIndex].ItemUnit + ">" + json.Data[rowIndex].ItemCode + "-" + json.Data[rowIndex].ItemName + "-" + json.Data[rowIndex].ItemStandard + "</option>");
            //    }
            //});
        }
    });

})