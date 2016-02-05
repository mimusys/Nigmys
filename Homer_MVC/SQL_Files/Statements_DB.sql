SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";

DROP TABLE IF EXISTS 'Statements';
CREATE TABLE Statements
(
	statementID INTEGER PRIMARY KEY
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'IncomeStatements';
CREATE TABLE IncomeStatements
(
	incomeStatementID INTEGER PRIMARY KEY,
	statementID INTEGER NOT NULL
	FOREIGN KEY (statementID) REFERENCES Statements(statementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CashFlowStatements';
CREATE TABLE CashFlowStatements
(
	cashFlowStatementID INTEGER PRIMARY KEY,
	statementID INTEGER NOT NULL,
	FOREIGN KEY (statementID) REFERENCES Statements(statementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'BalanceStatements';
CREATE TABLE BalanceStatements
(
	balanceStatementID INTEGER PRIMARY KEY,
	statementID INTEGER NOT NULL,
	FOREIGN KEY (statementID) REFERENCES Statements(statementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'InternalRateStatements';
CREATE TABLE InternalRateStatements
(
	internalRateStatementID INTEGER PRIMARY KEY,
	statementID INTEGER NOT NULL,
	FOREIGN KEY (statementID) REFERENCES Statements(statementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'RevenueList';
CREATE TABLE RevenueList
(
	revenueListID INTEGER PRIMARY KEY,
	incomeStatementID INTEGER NOT NULL,
	FOREIGN KEY (incomeStatementID) REFERENCES IncomeStatements(incomeStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'ExpenseList';
CREATE TABLE ExpenseList
(
	expenseListID INTEGER PRIMARY KEY,
	incomeStatementID INTEGER NOT NULL,
	FOREIGN KEY (incomeStatementID) REFERENCES IncomeStatements(incomeStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'BeforeTaxList';
CREATE TABLE BeforeTaxList
(
	beforeTaxListID INTEGER PRIMARY KEY,
	incomeStatementID INTEGER NOT NULL,
	FOREIGN KEY (incomeStatementID) REFERENCES IncomeStatements(incomeStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'AfterTaxList';
CREATE TABLE AfterTaxList
(
	afterTaxListID INTEGER PRIMARY KEY,
	incomeStatementID INTEGER NOT NULL,
	FOREIGN KEY (incomeStatementID) REFERENCES IncomeStatements(incomeStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CashInList';
CREATE TABLE CashInList
(
	cashInListID INTEGER PRIMARY KEY,
	cashFlowStatementID INTEGER NOT NULL,
	FOREIGN KEY (cashFlowStatementID) REFERENCES CashFlowStatements(cashFlowStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'AdditionsList';
CREATE TABLE AdditionsList
(
	additionsListID INTEGER PRIMARY KEY,
	cashFlowStatementID INTEGER NOT NULL,
	FOREIGN KEY (cashFlowStatementID) REFERENCES CashFlowStatements(cashFlowStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'DecreaseList';
CREATE TABLE DecreaseList
(
	decreaseListID INTEGER PRIMARY KEY,
	cashFlowStatementID INTEGER NOT NULL,
	FOREIGN KEY (cashFlowStatementID) REFERENCES CashFlowStatements(cashFlowStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'FinalCashFlowList';
CREATE TABLE FinalCashFlowList
(
	finalCashFlowListID INTEGER PRIMARY KEY,
	cashFlowStatementID INTEGER NOT NULL,
	FOREIGN KEY (cashFlowStatementID) REFERENCES CashFlowStatements(cashFlowStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CurrentAssetsList';
CREATE TABLE CurrentAssetsList
(
	currentAssetsListID INTEGER PRIMARY KEY,
	balanceStatementID INTEGER NOT NULL,
	FOREIGN KEY (balanceStatementID) REFERENCES BalanceStatements(balanceStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'FixedAssetsList';
CREATE TABLE FixedAssetsList
(
	fixedAssetsListID INTEGER PRIMARY KEY,
	balanceStatementID INTEGER NOT NULL,
	FOREIGN KEY (balanceStatementID) REFERENCES BalanceStatements(balanceStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'TotalAssestsList';
CREATE TABLE TotalAssestsList
(
	totalAssetListID INTEGER PRIMARY KEY,
	balanceStatementID INTEGER NOT NULL,
	FOREIGN KEY (balanceStatementID) REFERENCES BalanceStatements(balanceStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'LongTermLiabilitiesList';
CREATE TABLE LongTermLiabilitiesList
(
	longTermLiabilitiesListID INTEGER PRIMARY KEY,
	balanceStatementID INTEGER NOT NULL,
	FOREIGN KEY (balanceStatementID) REFERENCES BalanceStatements(balanceStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'OwnerEquityList';
CREATE TABLE OwnerEquityList
(
	ownerEquityListID INTEGER PRIMARY KEY,
	balanceStatementID INTEGER NOT NULL,
	FOREIGN KEY (balanceStatementID) REFERENCES BalanceStatements(balanceStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'LiabitilitesAndOwnerEquityList';
CREATE TABLE LiabitilitesAndOwnerEquityList
(
	liabilitiesAndOwnerEquityID INTEGER PRIMARY KEY,
	balanceStatementID INTEGER NOT NULL,
	FOREIGN KEY (balanceStatementID) REFERENCES BalanceStatements(balanceStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'InternalRateofReturnList';
CREATE TABLE InternalRateofReturnList
(
	internalRateofReturnListID INTEGER PRIMARY KEY,
	internalRateStatementID INTEGER NOT NULL,
	FOREIGN KEY (internalRateStatementID) REFERENCES InternalRateStatements(internalRateStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CashFlowandSaleList';
CREATE TABLE CashFlowandSaleList
(
	cashFlowAndSaleListID INTEGER PRIMARY KEY,
	internalRateStatementID INTEGER NOT NULL,
	FOREIGN KEY (internalRateStatementID) REFERENCES InternalRateStatements(internalRateStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'ReturnOnSaleList';
CREATE TABLE ReturnOnSaleList
(
	returnOnSaleListID INTEGER PRIMARY KEY,
	internalRateStatementID INTEGER NOT NULL,
	FOREIGN KEY (internalRateStatementID) REFERENCES InternalRateStatements(internalRateStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'RealizedUnrealizedAnalysisList';
CREATE TABLE RealizedUnrealizedAnalysisList
(
	realizedUnrealizedAnalysisListID INTEGER PRIMARY KEY,
	internalRateStatementID INTEGER NOT NULL,
	FOREIGN KEY (internalRateStatementID) REFERENCES InternalRateStatements(internalRateStatementID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'RevenueListItem';
CREATE TABLE RevenueListItem
(
	revenueListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	isRecurring boolean NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (revenueListID) REFERENCES RevenueList(revenueListID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'ExpenseListItem';
CREATE TABLE ExpenseListItem
(
	expenseListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	isRecurring boolean NOT NULL,
	yearlyListID INTEGER NOT NULL, 
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (expenseListID) REFERENCES ExpenseList(expenseListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'BeforeTaxListItem';
CREATE TABLE BeforeTaxListItem
(
	beforeTaxListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (beforeTaxListID) REFERENCES BeforeTaxList(beforeTaxListID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'AfterTaxListItem';
CREATE TABLE AfterTaxListItem
(
	afterTaxListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (afterTaxListID) REFERENCES AfterTaxList(afterTaxListID)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CashInListItem';
CREATE TABLE CashInListItem
(
	cashInListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (cashInListID) REFERENCES CashInList(cashInListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'AdditionsListItem';
CREATE TABLE AdditionsListItem
(
	additionsListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (additionsListID) REFERENCES AdditionsList(additionsListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'DecreaseListItem';
CREATE TABLE DecreaseListItem
(
	decreaseListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (decreaseListID) REFERENCES DecreaseList(decreaseListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'FinalCashFlowListItem';
CREATE TABLE FinalCashFlowListItem
(
	finalCashFlowListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (finalCashFlowListID) REFERENCES FinalCashFlowList(finalCashFlowListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CurrentAssetsListItem';
CREATE TABLE CurrentAssetsListItem
(
	currentAssetsListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (currentAssetsListID) REFERENCES CurrentAssetsList(currentAssetsListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'FixedAssetsListItem';
CREATE TABLE FixedAssetsListItem
(
	fixedAssetsListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (fixedAssetsListID) REFERENCES FixedAssetsList(fixedAssetsListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'TotalAssetsListItem';
CREATE TABLE TotalAssetsListItem
(
	totalAssetsListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (totalAssetsListID) REFERENCES TotalAssetsList(totalAssetsListID)	
);

SHOW ERRORS;


DROP TABLE IF EXISTS 'LongTermLiabilitiesListItem';
CREATE TABLE LongTermLiabilitiesListItem
(
	longTermLiabilitiesListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (longTermLiabilitiesListID) REFERENCES LongTermLiabilitiesList(longTermLiabilitiesListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'OwnerEquityListItem';
CREATE TABLE LongTermLiabilitiesListItem
(
	ownerEquityListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (ownerEquityListID) REFERENCES OwnerEquityList(ownerEquityListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'LiabilitiesAndOwnerEquityListItem';
CREATE TABLE LongTermLiabilitiesListItem
(
	liabilitiesAndOwnerEquityID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (liabilitiesAndOwnerEquityID) REFERENCES LiabilitiesAndOwnerEquityList(liabilitiesAndOwnerEquityListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'InternalRateOfReturnListItem';
CREATE TABLE InternalRateOfReturnListItem
(
	internalRateOfReturnListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (internalRateOfReturnListID) REFERENCES InternalRateOfReturnList(internalRateOfReturnListListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'CashFlowAndSaleListItem';
CREATE TABLE CashFlowAndSaleListItem
(
	cashFlowAndSaleListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (cashFlowAndSaleListID) REFERENCES CashFlowAndSaleList(cashFlowAndSaleListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'ReturnOnSaleListItem';
CREATE TABLE ReturnOnSaleListItem
(
	returnOnSaleListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (returnOnSaleListID) REFERENCES ReturnOnSaleList(returnOnSaleListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'RealizedUnrealizedAnalysisListItem';
CREATE TABLE RealizedUnrealizedAnalysisListItem
(
	realizedUnrealizedAnalysisListID INTEGER PRIMARY KEY,
	name VARCHAR(50) NOT NULL,
	yearlyListID INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID),
	FOREIGN KEY (realizedUnrealizedAnalysisListID) REFERENCES RealizedUnrealizedAnalysisList(realizedUnrealizedAnalysisListID)	
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'YearlyLists';
CREATE TABLE YearlyLists
(
	yearlyListID INTEGER PRIMARY KEY,
	listName VARCHAR(50) NOT NULL
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'YearlyListItem';
CREATE TABLE YearlyListItem
(
	yearlyListItemID INTEGER PRIMARY KEY,
	yearlyListID INTEGER NOT NULL,
	monthlyListID INTEGER NOT NULL,
	dateOf date NOT NULL,
	year INTEGER NOT NULL,
	value INTEGER NOT NULL,
	FOREIGN KEY (yearlyListID) REFERENCES YearlyLists(yearlyListID)
	FOREIGN KEY (monthlyListID) REFERENCES MonthlyLists(monthlyListID)
);

SHOW ERRORS;

DROP TABLE IF EISTS 'MonthlyLists';
CREATE TABLE MonthlyLists
(
	monthlyListID INTEGER PRIMARY KEY,
	listName VARCHAR (50) NOT NULL,
	FOREIGN KEY (listName) REFERENCES YearlyLists(listName)
);

SHOW ERRORS;

DROP TABLE IF EXISTS 'MonthlyListItem'
CREATE TABLE MonthlyListItem
(
	monthlyListItemID INTEGER PRIMARY KEY,
	monthlyListID INTEGER NOT NULL,
	dateOf date NOT NULL,
	month INTEGER NOT NULL,
	value INTEGER NOT NULL,
	FOREIGN KEY (monthlyListID) REFERENCES MonthlyLists(monthlyListID)

);

