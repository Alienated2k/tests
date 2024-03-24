using AltTester.AltTesterUnitySDK.Driver;
using NUnit.Framework;

public class AltTestDemo
{
	public AltDriver altDriver;

	[OneTimeSetUp]
	public void SetUp()
	{
		altDriver = new AltDriver();
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		altDriver.Stop();
	}

	[Test, Order(0)]
	public void Test_FindMainScreenHeaderAndAssertText()
	{
		var firstHeaderText = altDriver.FindObject(By.NAME, "Text");
		var getFirstHeaderText = firstHeaderText.GetText();

		Assert.AreEqual(getFirstHeaderText, "AltTestreUnity Demo Screen");
	}

	[Test, Order(1)]
	public void Test_FindPressButtonAndClick()
	{
		altDriver.SetDelayAfterCommand(0.25f);
		altDriver.FindObject(By.NAME, "Button_0").Click();
	}

	[Test, Order(2)]
	public void Test_FindInputFieldAndSetText()
	{
		altDriver.SetDelayAfterCommand(0.25f);

		var useInputField = altDriver.FindObject(By.NAME, "InputField");

		useInputField.Click();
		altDriver.SetDelayAfterCommand(0.25f);
		useInputField.SetText("Test Text", true);
	}

	[Test, Order(3)]
	public void Test_FindOkButtonAndClick()
	{
		altDriver.SetDelayAfterCommand(0.25f);
		altDriver.FindObject(By.NAME, "Button_1").Click();
	}

	[Test, Order(4)]
	public void Test_FindDropDownListAndSelectSecondItem()
	{
		altDriver.SetDelayAfterCommand(0.25f);
		altDriver.FindObject(By.NAME, "Dropdown").Click();
		altDriver.WaitForObjectWhichContains(By.NAME, "Second Item").Click();
	}

	[Test, Order(5)]
	public void Test_FindContinueButtonAndClick()
	{
		altDriver.SetDelayAfterCommand(0.25f);
		altDriver.FindObject(By.NAME, "Button_2").Click();
	}

	[Test, Order(6)]
	public void Test_FindSecondScreenHeaderAndAssert()
	{
		var secondHeaderText = altDriver.FindObject(By.NAME, "Text");
		var getSecondHeaderText = secondHeaderText.GetText();

		Assert.AreEqual(getSecondHeaderText, "Second Screen");
	}

	[Test, Order(7)]
	public void Test_FindSliderAndMoveItRight()
	{
		altDriver.SetDelayAfterCommand(0.25f);

		var handleObject = altDriver.FindObject(By.NAME, "Handle");
		var handlePosition = handleObject.GetScreenPosition();

		altDriver.MoveMouse(new AltVector2(handlePosition.x, handlePosition.y), 0.125f);
		altDriver.KeyDown(AltKeyCode.Mouse0, 1);
		altDriver.MoveMouse(new AltVector2(handlePosition.x + 75, handlePosition.y), 0.125f);
		altDriver.KeyUp(AltKeyCode.Mouse0);
	}

	[Test, Order(8)]
	public void Test_FindBackButtonAndClick()
	{
		altDriver.SetDelayAfterCommand(0.25f);
		altDriver.FindObject(By.NAME, "Button_3").Click();
	}
}