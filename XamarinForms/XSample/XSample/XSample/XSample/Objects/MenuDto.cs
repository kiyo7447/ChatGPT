namespace XSample.Objects
{
    public sealed class MenuDto
    {
        public MenuDto(string title, string subTitle, string imageName)
        {
            Title = title;
            SubTitle = subTitle;
            ImageName = imageName;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageName { get; set; }
    }
}
