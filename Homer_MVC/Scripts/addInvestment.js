function ammortizeLoan(loanAmount, years, annualPercent) {
    var monthlyPercent = annualPercent / 12.0;
    var numPayments = years * 12;
    return (monthlyPercent * loanAmount * Math.pow((1 + monthlyPercent), numPayments)) / (Math.pow(1 + monthlyPercent, numPayments) - 1);
}

function testDebtPartnerClass() {
    $('.debt-partner-row').each(function (i, obj) {
        alert($(this).find('.lenderName').val());
    });
}

$(document).ready(function () {
    // add new debt partner list item
    $('a#addDebtPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addDebtPartnerLinkRow').before('\
<div class="row debt-partner-row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="lenderName">Lender Name</label>\
            <input type="text" value="" class="form-control lenderName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <a href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></a>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="annualPercentageRate">Annual Percent</label>\
        <input type="text" value="" class="form-control annualPercentageRate" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-3">\
        <label for="loanStartDate">Loan Start Date</label>\
        <input type="date" value="" class="form-control loanStartDate">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="termLength">Term Length</label>\
        <input type="text" valud="" class="form-control termLength" placeholder="Years">\
    </div>\
</div>\
');
        return false;
    });

    // add new equity partner list item
    $('a#addEquityPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addEquityPartnerLinkRow').before('\
<div class="row equity-partner-row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="lenderName">Partner Name</label>\
            <input type="text" value="" class="form-control partnerName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="cashFlowPercent">Cash Flow</label>\
        <input type="text" value="" class="form-control cashFlowPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="appreciationPercent">Appreciation</label>\
        <input type="text" value="" class="form-control appreciationPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="principlePaydownPercent">Principle Paydown</label>\
        <input type="text" value="" class="form-control principlePaydownPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="taxDeductionPercent">Tax Deduction</label>\
        <input type="text" value="" class="form-control taxDeductionPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="equityInvestment">Equity Investment</label>\
        <input type="text" value="" class="form-control equityInvestment" placeholder="$0.00">\
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
        testDebtPartnerClass();
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
