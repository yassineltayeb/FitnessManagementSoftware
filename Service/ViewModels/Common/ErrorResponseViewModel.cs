namespace Service.ViewModels.Common;

public class ErrorResponseViewModel
{
    public ErrorResponseViewModel(int code, string error) =>
        (Code, Error) = (code, error);

    public int Code { get; set; } = 4;
    public string Error { get; set; }
}
