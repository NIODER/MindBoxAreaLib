select products.product_name, categories.category_name from products
left join products_to_categories
on products.id = products_to_categories.product_id
left join categories
on categories.id = products_to_categories.category_id;