// https://docs.cypress.io/api/table-of-contents

describe("The Probability Calculator", () => {
  before(() => {
    cy.visit("/");
    cy.title().should('eq', 'Probability Calculator');
  });

  it("should get the correct 'Combined with' result", () => {
    cy.get("#pA").clear().focus().type("0.5");
    cy.get("#pB").clear().focus().type("0.5");
    cy.get("#btn-combine").click();

    cy.get("#result").should(($div) => {
      expect($div.text().trim()).equal("0.25");
    });
  })

  it("should get the correct 'Either' result", () => {
    cy.get("#pA").clear().focus().type("0.5");
    cy.get("#pB").clear().focus().type("0.5");
    cy.get("#btn-either").click();

    cy.get("#result").should(($div) => {
      expect($div.text().trim()).equal("0.75");
    });
  })
})
