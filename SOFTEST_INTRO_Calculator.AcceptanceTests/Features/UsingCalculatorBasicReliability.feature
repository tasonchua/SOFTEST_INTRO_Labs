@BasicMusa
Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures and intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  Scenario: Current failure intensity at zero execution time
    Given I have a calculator
    And the Basic Musa values are 10, 100 and 0 hours
    When I calculate the current failure intensity
    Then the result should be 10

  Scenario: Current failure intensity after execution
    Given I have a calculator
    And the Basic Musa values are 10, 100 and 5 hours
    When I calculate the current failure intensity
    Then the result should be 6.065306597126334

  Scenario: Expected cumulative failures after execution
    Given I have a calculator
    And the Basic Musa values are 10, 100 and 5 hours
    When I calculate the expected cumulative failures
    Then the result should be 39.346934028736655

  Scenario: Reject invalid Basic Musa parameters
    Given I have a calculator
    And the Basic Musa values are 0, 100 and 5 hours
    When I calculate the current failure intensity
    Then the reliability calculation should be rejected