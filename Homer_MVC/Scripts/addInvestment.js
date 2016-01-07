$(document).ready(function () {
    $('a#addDebtPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addDebtPartnerLinkRow').before('\
<div class="row">\
    <div class="form-group col-lg-4">\
        <label for="lenderName">Lender Name</label>\
        <input type="text" value="" id="lenderName" class="form-control" name="lenderName">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="annualPercentageRate">Annual Percentage Rate</label>\
        <input type="text" value="" id="annualPercentageRate" class="form-control" name="annualPercentageRate" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="loanStartDate">Loan Start Date</label>\
        <input type="date" value="" id="loanStartDate" class="form-control" name="loanStartDate">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="termLength">Term Length (months)</label>\
        <input type="text" valud="" id="termLength" class="form-control" name="termLength" placeholder="Months">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style="min-height:42px; display:inline-block;"></span>\
        <a href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></a>\
    </div>\
</div>\
');
        return false;
    });

    $('a#addEquityPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addEquityPartnerLinkRow').before('\
<div class="row">\
    <div class="form-group col-lg-2">\
        <label for="lenderName">Partner Name</label>\
        <input type="text" value="" id="partnerName" class="form-control" name="partnerName">\
    </div>\
    <div class="form-group col-lg-1">\
        <label for="cashFlowPercent">Cash Flow</label>\
        <input type="text" value="" id="cashFlowPercent" class="form-control" name="cashFlowPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-1">\
        <label for="appreciationPercent">Appreciation</label>\
        <input type="text" value="" id="appreciationPercent" class="form-control" name="appreciationPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="principlePaydownPercent">Principle Paydown</label>\
        <input type="text" value="" id="principlePaydownPercent" class="form-control" name="principlePaydownPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-1">\
        <label for="taxDeductionPercent">Tax Deduction</label>\
        <input type="text" value="" id="taxDeductionPercent" class="form-control" name="taxDeductionPercent" placeholder="%0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="equityInvestment">Equity Investment</label>\
        <input type="text" value="" id="equityInvestment" class="form-control" name="equityInvestment" placeholder="$0.00">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style="min-height:42px; display:inline-block;"></span>\
        <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
    </div>\
</div>\
');
        return false;
    });

    $('a#addDepreciationLink').click(function (e) {
        e.preventDefault();
        $('#addDepreciationLinkRow').before('\
<div class="row">\
    <div class="form-group col-lg-2">\
        <label for="depreciationName">Depreciation Name</label>\
        <input type="text" value="" id="depreciationName" class="form-control" name="depreciationName">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="depreciationValue">Depreciation Value</label>\
        <input type="text" value="" id="depreciationValue" class="form-control" name="depreciationValue" placeholder="$0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="timeDuration">Time Duration</label>\
        <input type="text" value="" id="timeDuration" class="form-control" name="timeDuration" placeholder="">\
    </div>\
    <div class="form-group col-lg-1">\
        <span style="min-height:42px; display:inline-block;"></span>\
        <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
    </div>\
</div>\
');
        return false;
    });

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
});

$(document).on("click", ".removeButton", function () {
    $(this).parent().parent().remove();
});
