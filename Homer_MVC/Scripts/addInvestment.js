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

function addNewInvestment() {
    // todo: add input validation

    // assemble debt partner class array
    var debtPartners = [];
    $('.debt-partner-row').each(function (i, obj) {
        var termLength = $(this).find('.termLength').val();
        var annualPercentageRate = $(this).find('.annualPercentageRate').val()/100.0;
        var loanAmount = $(this).find('.loanAmount').val();
        var payment = ammortizeLoan(loanAmount, termLength, annualPercentageRate);
        debtPartners.push(
            {
                LenderName: $(this).find('.lenderName').val(),
                Term: termLength,
                AnnualPercentageRate: annualPercentageRate,
                LoanStartDate: $(this).find('.loanStartDate').val(),
                LoanAmount: loanAmount,
                Payment: payment
            });
    });
    
    // assemble cost item class array
    var costItems = [];
    costItems.push({
        CostItemName: "Closing Cost",
        CostItemValue: $('#closingCost').val()
    });

    costItems.push({
        CostItemName: "Rehab Cost",
        CostItemValue: $('#rehabCost').val()
    });

    costItems.push({
        CostItemName: "Holdover Cost",
        CostItemValue: $('#holdoverCost').val()
    });

    $('.other-cost-row').each(function (i, obj) {
        costItems.push(
            {
                CostItemName: $(this).find('.otherCostName').val(),
                CostItemValue: $(this).find('.otherCostValue').val()
            });
    });

    // assemble equity partner class array
    var equityPartners = [];
    $('.equity-partner-row').each(function (i, obj) {
        equityPartners.push({
            EquityPartnerName: $(this).find('.partnerName').val(),
            CashFlowPercent: $(this).find('.cashFlowPercent').val() / 100.0,
            AppreciationPercent: $(this).find('.appreciationPercent').val() / 100.0,
            PrincipalPaydownPercent: $(this).find('.principalPaydownPercent').val() / 100.0,
            TaxDeductionPercent: $(this).find('.taxDeductionPercent').val() / 100.0,
            EquityInvestment: $(this).find('.equityInvestment').val()
        });
    });

    // assemble depreciation item class array
    var depreciationItems = [];
    $('.depreciation-item-row').each(function (i, obj) {
        depreciationItems.push({
            DepreciationItemName: $(this).find('.depreciationName').val(),
            DepreciationItemValue: $(this).find('.depreciationValue').val(),
            DepreciationItemTimeDuration: $(this).find('.timeDuration').val()
        });
    });

    // construct investment information object
    var investmentInformation = {
        // purchase info
        PurchasePrice: $('#purchasePrice').val(),
        PurchaseDate: $('#purchaseDate').val(),
        MarketPrice: $('#marketPrice').val(),
        LandValue: $('#landValue').val(),
        DownPayment: $('.downPayment').first().val(),
        TotalInvestmentCost: $('#totalInvestmentCost').val(),

        // property info
        Address: $('#address').val(),
        City: $('#city').val(),
        State: $('#state').val(),
        Bedrooms: $('#bedrooms').val(),
        Baths: $('#baths').val(),
        SquareFootage: $('#squareFootage').val(),
        PricePerSqFoot: $('#pricePerSqFoot').val(),

        // potential return info
        AnnualAppreciationRate: $('#annualAppreciationRate').val() / 100.0,
        SalesCommission: $('#salesCommission').val() / 100.0,
        CapitalGainsTax: $('#capitalGainsTax').val() / 100.0,
        IncomeTaxRate: $('#incomeTaxRate').val() / 100.0,
        DiscountRate: $('#discountRate').val(),

        CostItems: costItems,
        DebtPartners: debtPartners,
        EquityPartners: equityPartners,
        DepreciationItems: depreciationItems
    };

    $.ajax({
        url: '/Investments/AddInvestment',
        type: 'POST',
        dataType: 'json',
        cache: false,
        async: false,
        data: JSON.stringify(investmentInformation),
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                success = true;
            } else alert("Failed to create new user.");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(thrownError);
        }
    });
}

$(document).ready(function () {
    // add new debt partner list item
    $('a#addDebtPartnerLink').click(function (e) {
        e.preventDefault();
        $('#addDebtPartnerLinkRow').before('\
<div class="row debt-partner-row">\
    <hr />\
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
        <label for="loanAmount">Loan Amount</label>\
        <input type="text" value="" class="form-control loanAmount" placeholder="$0.00" />\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="annualPercentageRate">Annual Percent</label>\
        <input type="text" value="" class="form-control annualPercentageRate" placeholder="%0.00" />\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="loanStartDate">Loan Start Date</label>\
        <input type="date" value="" class="form-control loanStartDate" />\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="termLength">Term Length</label>\
        <input type="text" valud="" class="form-control termLength" placeholder="Years" />\
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
            <label for="partnerName">Partner Name</label>\
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
        <input type="text" value="" class="form-control principalPaydownPercent" placeholder="%0.00">\
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
<div class="row depreciation-item-row">\
    <div class="row nested-row">\
        <div class="form-group col-lg-4">\
            <label for="depreciationName">Name</label>\
            <input type="text" value="" class="form-control depreciationName">\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <button type="button" href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></button>\
        </div>\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="depreciationValue">Value</label>\
        <input type="text" value="" class="form-control depreciationValue" placeholder="$0.00">\
    </div>\
    <div class="form-group col-lg-2">\
        <label for="timeDuration">Duration</label>\
        <input type="text" value="" class="form-control timeDuration" placeholder="">\
    </div>\
</div>\
');
        return false;
    });

    // add custom cost item
    $('a#addOtherCostLink').click(function (e) {
        e.preventDefault();
        $('#addOtherCostLinkRow').before('\
<div class="row other-cost-row">\
    <div>\
        <div class="form-group col-lg-6">\
            <label for="otherCostName">Name</label>\
            <input type="text" value="" class="form-control otherCostName"></input>\
        </div>\
        <div class="form-group col-lg-4">\
            <label for="otherCostValue">Amount</label>\
            <input type="text" value="" class="form-control otherCostValue" placeholder="$0.00"></input>\
        </div>\
        <div class="form-group col-lg-1">\
            <span style="min-height:42px; display:inline-block;"></span>\
            <a href="#" class="btn pull-down btn-default btn-circle removeButton" type="button"><i class="fa fa-times"></i></a>\
        </div>\
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
    })

    $('.prev').click(function () {
        var prevId = $(this).parents('.tab-pane').prev().attr("id");
        $('[href=#' + prevId + ']').tab('show');
    })

    $('.submit').click(function (e) {
        e.preventDefault();
        addNewInvestment();
        return false;
    })
});

// remove an added list item field
$(document).on("click", ".removeButton", function () {
    $(this).parent().parent().parent().remove();
});
