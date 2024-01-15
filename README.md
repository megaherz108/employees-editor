# Example C# application

### Specification

Console application should handle text file with a list of employees in JSON.

Employee record format:
- Id, int
- FirstName, string
- LastName, string
- SalaryPerHour, decimal.

Application gets input arguments (from **string[] args** of method Main) and performs appropriate operation.

The following arguments and operations are allowed:

1. -**add FirstName:John LastName:Doe SalaryPerHour:100.50.**

   Adds a new record to a file. Fields FirstName, LastName and SalaryPerHour are filled from arguments. Field Id is generated automatically based on Id field value of previous record (plus one).
    
2. **-update Id:123 FirstName:James**

   Updates record with Id=123 and changes field FirstName to a new value. Any field can be updated except Id. If there is no record with specified Id, an error should be shown in the console.

3. **-get Id:123**

   Outputs a string of format «Id = {Id}, FirstName = {FirstName}, LastName = {LastName}, SalaryPerHour = {SalaryPerHour}» with appropriate values from a record with specified Id. If there is no record with   specified Id, an error should be shown in the console.

4. **-delete Id:123**

   Deletes a record with Id=123 from file. If there is no record with specified Id, an error should be shown in the console.

5. **-getall**

   Returns a list of all employees. Format is the same as specified for -get command.
