import re

def detect_credit_card_brand(card_number):

    # スペースとハイフン（全角も含む）を取り除く
    card_number = re.sub(r"[\s-]|[\u3000]|[－]", "", card_number)

    # Visa
    if re.match(r"^4[0-9]{12}(?:[0-9]{3})?$", card_number):
        return "Visa"

    # MasterCard
    if re.match(r"^5[1-5][0-9]{14}$", card_number):
        return "MasterCard"

    # American Express
    if re.match(r"^3[47][0-9]{13}$", card_number):
        return "American Express"

    # Diners Club
    if re.match(r"^3(?:0[0-5]|[68][0-9])[0-9]{11}$", card_number):
        return "Diners Club"

    # Discover
    if re.match(r"^6(?:011|5[0-9]{2})[0-9]{12}$", card_number):
        return "Discover"

    # JCB
    if re.match(r"^(?:2131|1800|35\d{3})\d{11}$", card_number):
        return "JCB"

    # Unknown brand
    return "Unknown"

if __name__ == "__main__":
    # Sample card number
    card_number = "378282246310005"

    # Detect credit card brand
    brand = detect_credit_card_brand(card_number)

    # Print result
    print("Credit Card Brand:", brand)

    while True:
        # ユーザからの入力を受け付ける
        card_number = input("Enter a credit card number (or press enter to quit): ")

        # 入力が空の場合、終了
        if not card_number:
            break

        # クレジットカードブランドの判定
        brand = detect_credit_card_brand(card_number)
        print("Credit Card Brand:", brand)
