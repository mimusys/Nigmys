$(document).ready(function () {
    // add new debt partner list item
    $('a#addDebtPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addDebtPartnerLinkRow').before('\
<div class="row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="lenderName">Lender Name</label>\
            <input type="text" value="" id="lenderName" class="form-control" name="lenderName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <a href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></a>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="annualPercentageRate">Annual Percent</label>\
        <input type="text" value="" id="annualPercentageRate" class="form-control" name="annualPercentageRate" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-3">\
        <label for="loanStartDate">Loan Start Date</label>\
        <input type="date" value="" id="loanStartDate" class="form-control" name="loanStartDate">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="termLength">Term Length</label>\
        <input type="text" valud="" id="termLength" class="form-control" name="termLength" placeholder="Years">\
    </div>\
</div>\
');
        return false;
    });

    // add new equity partner list item
    $('a#addEquityPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addEquityPartnerLinkRow').before('\
<div class="row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="lenderName">Partner Name</label>\
            <input type="text" value="" id="partnerName" class="form-control" name="partnerName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="cashFlowPercent">Cash Flow</label>\
        <input type="text" value="" id="cashFlowPercent" class="form-control" name="cashFlowPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="appreciationPercent">Appreciation</label>\
        <input type="text" value="" id="appreciationPercent" class="form-control" name="appreciationPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="principlePaydownPercent">Principle Paydown</label>\
        <input type="text" value="" id="principlePaydownPercent" class="form-control" name="principlePaydownPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="taxDeductionPercent">Tax Deduction</label>\
        <input type="text" value="" id="taxDeductionPercent" class="form-control" name="taxDeductionPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="equityInvestment">Equity Investment</label>\
        <input type="text" value="" id="equityInvestment" class="form-control" name="equityInvestment" placeholder="$0.00">\
    </div>\
</div>\
');
        return false;
    });

    // add depreciation list item
    $('a#addDepreciationLink').click(function (e) {
        e.preventDefault();
        $('#addDepreciationLinkRow').before('\
<div class="row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="depreciationName">Name</label>\
            <input type="text" value="" id="depreciationName" class="form-control" name="depreciationName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="depreciationValue">Value</label>\
        <input type="text" value="" id="depreciationValue" class="form-control" name="depreciationValue" placeholder="$0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="timeDuration">Duration</label>\
        <input type="text" value="" id="timeDuration" class="form-control" name="timeDuration" placeholder="">\
    </div>\
</div>\
');
        return false;
    });

    // add custom cost item
    $('a#addOtherCostLink').click(function (e) {
        e.preventDefault();
        $('#addOtherCostLinkRow').before('\
<div class="row">\
    <div class="form-group col-lg-6">\
        <label for="otherCostName">Name</label>\
        <input type="text" value="" class="form-control" id="otherCostName"></input>\
    </div>\
    <div class="form-group col-lg-4">\
        <label for="otherCostValue">Amount</label>\
        <input type="text" value="" class="form-control" id="otherCostValue" placeholder="$0.00"></input>\
    </div>\
    <div class="form-group col-lg-1">\
        <span style="min-height:22px; display:inline-block;"></span>\
        <a href="#" class="btn pull-down btn-default btn-circle removeButton" onclick="test()" type="button"><i class="fa fa-times"></i></a>\
    </div>\
</div>');
        return false;
    });


    //add Expense Item
    $('a#addExpenseItemLink').click(function (e) {
        e.preventDefault();
        $('#addExpenseItemLinkRow').before('\
<div class="col-lg-12">\
    <div class="row">\
        <div class="form-group col-lg-4">\
            <label for ="expenseName">Name<\label>\
            <input type="text" value="" id="expenseName" class="form-control" name="expenseName">\
        </div>\
        <div class="form-group col-lg-4">\
            <label for="expenseRecurrence">Recurring<\label><input\
            <input type="checkbox" class="recurringCheckbox">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style = "min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
         </div>\
        <div class="row">\
            <div class="col-lg-4" style="padding-left:4em;">\
                <a href="#" class="addExpenseItemRow">Add Expense Date Row</a>\
            </div>\
        </div>\
        <div class="col-lg-12 expenseItemValueRows">\
            <div class="form-group col-lg-2">\
                <label for="expenseDate" id = "expenseDateText" >Date</label>\
                <input type="text" value="" id="expenseDate" class="form-control" name="expenseDate" placeholder="mm/dd/yyyy">\
            </div>\
             <div class="form-group col-lg-2">\
                <label for="expenseValue" id="expenseValueText">Value</label>\
                <input type="text" value="" id="expenseValue1" class = "form-control" name="expenseValue" placeholder = "$0.00">\
            </div>\
        </div>\
    <\div>\
</div>');
        return false;

    });

    // toggle tab colors
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $('a[data-toggle="tab"]').removeClass('btn-primary');
        $('a[data-toggle="tab"]').addClass('btn-default');
        $(this).removeClass('btn-default');
        $(this).addClass('btn-primary');
    });

    $('.next').click(function () {
        var nextId = $(this).parents('.tab-pane').next().attr("id");
        $('[href=#' + nextId + ']').tab('show');
    })

    $('.prev').click(function () {
        var prevId = $(this).parents('.tab-pane').prev().attr("id");
        $('[href=#' + prevId + ']').tab('show');
    })
});

// remove an added list item field
$(document).on("click", ".removeButton", function () {
    $(this).parent().parent().parent().remove();
});

$(document).on("click", ".addButton", function () {
    $(this).parent().append();
});

$(document).on("click", ".expenseItemRowRemove", function () {
    $(this).parent().parent().remove();
});

//$("#plusButton").click(function () {
$(document).on("click", ".addExpenseItemRow", function () {
    //alert('add expense recurring item row');
    if ($('.addExpenseItemRow').parent().parent().parent().find('.recurringCheckbox').is(':checked')) {
        $(this).parent().parent().parent().find('.expenseItemValueRows').append('\
<div class="row expenseRecurringRow">\
    <div class="form-group col-lg-2">\
        <label for="purchaseDate">To</label>\
        <input type="text" value="" id="expensePurchaseTODate" class="form-control" name="expensePurchaseToDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="purchaseDate">From</label>\
        <input type="text" value="" id="expensePurchaseFromDate" class="form-control" name="expensePurchaseFromDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="expenseValue">Value</label>\
        <input type="text" value="" id="expenseValue" class="form-control" name="expenseValue" placeholder="$0.00">\
    </div>\
    <div class = "form-group col-lg-4">\
        <label for="expenseProrate">Prorated<\label><input\
        <input type = "checkbox" value="" id="Prorated" name = "Prorated">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style = "min-height:42px; display:inline-block;"></span>\
        <a href="#" class="btn pull-down btn-default btn-circle expenseItemRowRemove"><i class="fa fa-times"></i></a>\
    </div>\
</div>');
    } else {
        $(this).parent().parent().parent().find('.expenseItemValueRows').append('\
 <div class="row col-lg-12 expenseItemValueRow">\
    <div class="form-group col-lg-2">\
        <label for="expenseDate" id = "expenseDateText" >Date</label>\
        <input type="text" value="" id="expenseDate" class="form-control" name="expenseDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class = "form-group col-lg-2">\
        <label for="expenseValue" id = "expenseValueText">Value</label>\
        <input type="text" value="" id="expenseValue1" class = "form-control" name="expenseValue" placeholder = "$0.00">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style = "min-height:42px; display:inline-block;"></span>\
        <a href="#" class="btn pull-down btn-default btn-circle expenseItemRowRemove"><i class="fa fa-times"></i></a>\
    </div>\
</div>');
    }
});

$(document).on("change", ".recurringCheckbox", function () {
    var parentDiv = $(this).parent().parent().parent().parent();
    parentDiv.children('.expenseItemValueRows')[0].remove();
    if ($(this).is(':checked')) {
        parentDiv.append('\
<div class="col-lg-12 expenseItemValueRows">\
    <div class="row expenseRecurringRow">\
        <div class="form-group col-lg-2">\
            <label for="purchaseDate">To</label>\
            <input type="text" value="" id="expensePurchaseTODate" class="form-control" name="expensePurchaseToDate" placeholder="mm/dd/yyyy">\
        </div>\
        <div class="form-group col-lg-2">\
            <label for="purchaseDate">From</label>\
            <input type="text" value="" id="expensePurchaseFromDate" class="form-control" name="expensePurchaseFromDate" placeholder="mm/dd/yyyy">\
        </div>\
        <div class="form-group col-lg-2">\
            <label for="expenseValue">Value</label>\
            <input type="text" value="" id="expenseValue" class="form-control" name="expenseValue" placeholder="$0.00">\
        </div>\
        <div class = "form-group col-lg-4">\
            <label for="expenseProrate">Prorated<\label><input\
            <input type = "checkbox" value="" id="Prorated" name = "Prorated">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style = "min-height:42px; display:inline-block;"></span>\
            <a href="#" class="btn pull-down btn-default btn-circle expenseItemRowRemove"><i class="fa fa-times"></i></a>\
        </div>\
    </div>\
</div>');

    } else {

        parentDiv.append('\
<div class="col-lg-12 expenseItemValueRows">\
    <div class="form-group col-lg-2">\
        <label for="expenseDate" id = "expenseDateText" >Date</label>\
        <input type="text" value="" id="expenseDate" class="form-control" name="expenseDate" placeholder="mm/dd/yyyy">\
    </div>\
    <div class = "form-group col-lg-2">\
        <label for="expenseValue" id = "expenseValueText">Value</label>\
        <input type="text" value="" id="expenseValue1" class = "form-control" name="expenseValue" placeholder = "$0.00">\
    </div>\
</div>');

    }

});