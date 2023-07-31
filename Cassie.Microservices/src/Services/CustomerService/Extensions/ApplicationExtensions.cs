namespace CustomerService.Extensions
{
	public static class ApplicationExtensions
	{
		public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment enviroment)
		{
			if (enviroment.IsDevelopment())
			{
                app.UseSwagger();
				app.UseSwaggerUI();
            }

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseRouting();
		}
	}
}