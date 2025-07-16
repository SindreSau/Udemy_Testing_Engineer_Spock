# Naming conventions for testing

## Test Method Naming

1. **Use the `Should` prefix** for test methods to indicate the expected behavior.  
    This makes it clear that the method is a test and describes the expected outcome.
   
   _Example:_ `ShouldReturnTrueWhenConditionIsMet`


2. **Use descriptive names** that indicate the scenario being tested.  
This helps in understanding what the test is verifying without needing to read the implementation.
   
   _Example:_ `ShouldThrowExceptionWhenInputIsInvalid`


3. **Use the UnitUnderTest_Scenario_ExpectedBehavior` format** for clarity.
    This format provides a clear structure to the test name, making it easier to understand what is being tested.
    
    _Example:_ `Calculator_AddTwoNumbers_ReturnsSum`


4. **Use the `Given_When_Then` pattern** for complex scenarios.  
This pattern provides a clear structure to the test, making it easier to follow the logic.

   _Example:_ `GivenValidInput_WhenMethodIsCalled_ThenReturnsExpectedResult`


