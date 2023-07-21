namespace ProductService.Extensions
{
	public static class ApplicationExtensions
	{
		public static void UseInfrastructure(this IApplicationBuilder app, IWebHostEnvironment enviroment)
		{
            // Configure the HTTP request pipeline.
            if (enviroment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
        }
	}
}

