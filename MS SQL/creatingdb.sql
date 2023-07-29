use productsdb;

create table categories
(
        id int not null identity primary key,
        category_name varchar(120) not null,
        constraint AK_category_name unique(category_name)
);

create table products
(
        id int identity primary key,
        product_name varchar(120) not null,
        constraint AK_product_name unique(product_name)
);

create table products_to_categories
(
	product_id int not null references products(id) on delete cascade,
	category_id int not null references categories(id) on delete cascade,
	constraint PK_products_to_categories primary key (product_id, category_id)
);