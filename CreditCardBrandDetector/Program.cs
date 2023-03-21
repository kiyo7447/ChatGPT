using System;
using System.Text.RegularExpressions;

// サンプルのカード番号
string cardNumber = "378282246310005";

// クレジットカードブランドを判定
string brand = DetectCreditCardBrand(cardNumber);

// 結果を表示
Console.WriteLine("Credit Card Brand: " + brand);

while (true)
{
	// ユーザからの入力を受け付ける
	Console.Write("Enter a credit card number (or press enter to quit): ");
	cardNumber = Console.ReadLine();

	// 入力が空の場合、終了
	if (string.IsNullOrEmpty(cardNumber))
		break;

	// クレジットカードブランドの判定
	brand = DetectCreditCardBrand(cardNumber);
	Console.WriteLine("Credit Card Brand: " + brand);
}


// クレジットカード番号からブランドを判定するメソッド
static string DetectCreditCardBrand(string cardNumber)
{
	// スペースとハイフン（全角も含む）を取り除く
	cardNumber = Regex.Replace(cardNumber, @"[\s-]|[\u3000]|[－]", "");

	// Visa
	if (Regex.IsMatch(cardNumber, @"^4[0-9]{12}(?:[0-9]{3})?$"))
		return "Visa";

	// MasterCard
	if (Regex.IsMatch(cardNumber, @"^5[1-5][0-9]{14}$"))
		return "MasterCard";

	// American Express
	if (Regex.IsMatch(cardNumber, @"^3[47][0-9]{13}$"))
		return "American Express";

	// Diners Club
	if (Regex.IsMatch(cardNumber, @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$"))
		return "Diners Club";

	// Discover
	if (Regex.IsMatch(cardNumber, @"^6(?:011|5[0-9]{2})[0-9]{12}$"))
		return "Discover";

	// JCB
	if (Regex.IsMatch(cardNumber, @"^(?:2131|1800|35\d{3})\d{11}$"))
		return "JCB";

	// その他のブランド
	return "Unknown";
}
