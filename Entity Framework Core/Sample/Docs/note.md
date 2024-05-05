+ Context object đại diện cho một session của database.
+ EFCore thao tác với nhiều loại csdl khác nhau dựa vào Database Provider.
+ Với navigation property, EF Core thông dịch khóa ngoại theo format <navigation property name><primary key property name>. hoặc <primary key property name>.
+ scaffolding engine chưa hỗ trợ nullable type.
+ An EF Core context isn't thread safe: don't try to do multiple operations in parallel.
+ 