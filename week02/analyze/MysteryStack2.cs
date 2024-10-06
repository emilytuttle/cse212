﻿public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        var stack = new Stack<float>();
        // 5 3 7 + *
        foreach (var item in text.Split(' ')) {
            // '5', '3', '7', '+', '*'
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

// Determine the result of the function if the following inputs were provided:
// 5 3 7 + *
// 6 2 + 5 3 - /

// Consider possible values for the input parameter text that would result in the function doing the following:
// Display "Invalid Case 1!" - not numbers to multiply
// Display "Invalid Case 2!" - last number = 0, can't divide by 0
// Display "Invalid Case 3!"- item is not a number, math symbol, or a blank space
// Display "Invalid Case 4!" - there was nothing added to the stack