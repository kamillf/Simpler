# Code Review Checklist
written by [Jason Jones][author]

    Author's Notes

    This checklist is intended to serve as an aid when you are performing a code
    review. It is not comprehensive, not every question will apply to every
    review, and there will always be additional considerations depending on the
    project, client, team, and problem being solved. However, it should serve as
    a reasonable starting point for any technical code review.
    
    I intend for this to be a living document, so pull requests are welcome.

## Underlying Problem

### What problem is this trying to solve?

> Consider the [Five Ws][five-ws]
>
> * Who is it about?
> * What happened?
> * Where did it take place?
> * When did it take place?
> * Why did it happen?
> * How did it happen?

### Do I understand the problem?

> Summarize the problem in a few sentences. If you can't restate the problem,
> you probably don't understand it.

### Have we solved this problem before?

> * Yes
>     * Can we use the existing solution here? If not, is it reasonable to
>       extend it to handle this variant?

> * No
>     * Is it similar to any problems we've already solved?
>     * How does it differ from what we've solved and what is the impact of those differences?
>     * What issues did we have with the previous solution that are likely to occur here?

## Logicalness

### Does it make sense?

> "It" is the code, but also the broader context within which the code exists.
> Assessing whether it makes sense is often based on experience and intuition
> and is a developed skill.

### If not, what specifically does not make sense?

> Consider what changes or additional information might be required for it to
> make sense.

### Is there a clear design?

> Consider carefully--design doesn't imply a formal Word document. Design is the
> sum total of the decisions made and is reflected in all aspects, including but
> not limited to:
>
> * Class, method, and variable names
> * Data structures
> * Unit tests
> * Comments
> * Structural organization

## Conventions and Cleanliness

### Does the code conform to the current conventions, idioms, and patterns for the language?

> Consider referencing existing resources that cover these topics:

> * [Framework Design Guideline: Conventions, Idioms, and Patterns for Reusable .NET Libraries][dot-net-style]
> * [Ruby Style Guide][ruby-style]
> * [Style Guide for Python Code][python-style]

### Does the code conform to the project's conventions, idioms, and patterns for the language?

> Almost every project will establish its own conventions, idioms, and patterns.
>
> These may or may not be in line with the current commonly accepted versions.
>
> In general, the project's established versions should take precedence as
> consistent code is preferable.
>
> However, this does not mean they should blindly followed when they don't make
> sense: there is nothing sacred about current practices and they inevitably
> change over time. It's a developer's obligation to challenge the status quo
> and raise these issues for discussion with the project team.

### Is the code clean?

> All unused code, junk comments, and commented out code should be removed.

## Understanding

### Do I understand the code?

### If I don't understand the code, what aspect of it do I not understand?

> * Is it a design issue?
> * Is it a deviation from accepted conventions, idioms, and patterns?
> * Is it something intrinsic to the language?
> * Is it something intrinsic to the problem being solved?

### Is there something I can do to better understand the code?

## Fit for Purpose / Does it Work?

### Does the code actually do what it says it does?

> It is entirely possible to write code where intent does not correlate with
> implementation.

> Consider unit tests as one mechanism for validating this, remembering that
> unit tests are still code that must be reviewed for all of the same issues as
> the code being tested.

## Code Reuse and Flexibility

### Does the code contain an original implementation of something that already exists as reusable library code?

> If so, consider updating the code to utilize the reusable library code.

### Does the code contain an original implementation of something that should be reusable library code?

> If so, consider extracting the relevant code to the reusable library.

### Does the code contain hard-coded elements that should be externalized to configuration?

## Reliability and Robustness

### Does the code handle scenarios other than the "happy path"?

> * Does the code validate inputs?
> * Does the code handle errors?
> * Does the code handle errors correctly?
> * Does the code ensure that resources are released in all scenarios?

### If the code only handles the "happy path", should it handle other scenarios?

> * What are the expectations of the consumer of this code?
> * Should errors be handled here or allowed to propagate and handled at a higher level?
> * In what context is this code run?
> * What are the consequences of failure for this code?

## Review Quality

*Do I have time to give this review the comprehensive assessment it deserves?*

*Is my review purely superficial?*

*Am I writing good feedback?*

Focus on providing clear actionable feedback that the developer can act on.

Where applicable, try to provide rationale for requested changes.

[dot-net-style]: http://www.amazon.com/Framework-Design-Guidelines-Conventions-Libraries/dp/0321545613
[ruby-style]: https://github.com/bbatsov/ruby-style-guide
[python-style]: http://legacy.python.org/dev/peps/pep-0008
[five-ws]: http://en.wikipedia.org/wiki/Five_Ws
[author]: https://github.com/ralreegorganon
