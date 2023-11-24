# RBAC ACCESS CONTROL MODEL

"Legend:"  
"X = Perform"  
"O = does not perform"  
"? = unknown"  

| Permission Id       | Service Capability           | Anonymous        | Visa Applicant    | Visa Agent      | Support Specialist | Branch Manager     | Admin             | endpoint           | constraints       |
|----------------------|-------------------|-------------------|-------------------|-------------------|----------------------|--------------------|-------------------|---------------------|-------------------|
| [P-001]    | [Login]       | [X]     | [X]| [X] | [X]| [X] | [X]         | [GET + /Auth/Login]        |  |
| [P-002]    | [Registration]       | [X]     | [X]| [X] | [X]| [X] | [X]  | [POST + /Auth/register]       |   |
| [P-003]    | [GetSuggestion]       | [O]     | [X]| [O]| [O] | [O]| [O] | [GET + /Visa/Suggestion ]     |   |
| [P-004]    | [FindAllForCountry]       | [O]     | [X]| [X] | [X]| [O] | [O]         | [GET + /Visa/FindAllForCountry]| |
| [P-005]    | [FindSpecificVisa]       | [O]     | [X]| [X] | [X]| [O] | [O]         | [GET + /Visa/FindVisa]|   |
| [P-006]    | [StartApplication]       | [O]     | [X]| [O] | [O]| [O] | [O]         | [GET + /Visa/Application/Start]        | [Must have a visa id via suggestion or find apis]   |
| [P-007]    | [SaveApplication]       | [O]     | [X]| [O] | [O]| [O] | [O]         | [POST + /Visa/Application/Save]        |    |
| [P-008]    | [SubmitApplication]       | [O]     | [X]| [O] | [O]| [O] | [O]         | [Get + /Visa/Application/Submit]        |    |
| [P-009]    | [ResumeApplication]       | [O]     | [X]| [O] | [O]| [O] | [O]         | [GET + /Visa/Application/Resume]        |    |
| [P-010]    | [GetApplication]       | [O]     | [X]| [O] | [O]| [O] | [O]         | [GET + /Visa/Application/GetApplication]        |    |