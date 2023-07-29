insert into categories (category_name) values ('shoes');
insert into categories (category_name) values ('shirts');
insert into categories (category_name) values ('skirts');
insert into categories (category_name) values ('hats');

insert into products (product_name) values ('shoes1');
insert into products (product_name) values ('shoes2');

insert into products (product_name) values ('shirt1');
insert into products (product_name) values ('shirt2');

insert into products (product_name) values ('skirt1');
insert into products (product_name) values ('skirt2');

insert into products (product_name) values ('unknown');

insert into products_to_categories (product_id, category_id) values (1, 1);
insert into products_to_categories (product_id, category_id) values (2, 1);
insert into products_to_categories (product_id, category_id) values (3, 2);
insert into products_to_categories (product_id, category_id) values (4, 2);
insert into products_to_categories (product_id, category_id) values (5, 3);
insert into products_to_categories (product_id, category_id) values (6, 3);