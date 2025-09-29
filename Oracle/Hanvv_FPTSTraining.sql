-----------Products------------
select * from products

--sp insert product
CREATE OR REPLACE procedure add_products(
v_id in products."Id"%type,
v_status in products.status%Type,
v_code in products."Code"%Type,
v_name in products."Name"%Type,
v_createDate in products."CreateDate"%Type,

v_createBy in products."CreateBy"%Type,

v_offset in products."Offsets"%Type,
v_partition in products."Partitions"%Type
)
is 
v_count number;
begin

select  count(*) into v_count from products
where products."Id" = v_id;
if v_count > 0 then
dbms_output.put_line('Tr�ng id');
return;
end if;

select  count(*) into v_count from products
where products."Code" = v_code;
if v_count > 0 then
dbms_output.put_line('Tr�ng code');
return;
end if;

insert into products("Id", status, "Code", "Name" , "CreateDate", "UpdateDate", "CreateBy", "UpdateBy", "Offsets", "Partitions")
values (product_insert_seq.NEXTVAL,v_status,v_code,v_name,v_createDate,null,v_createBy,null,v_offset,v_partition);
dbms_output.put_line('Th�m th�nh c�ng');
exception when others then
dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
end;

--sp update product
create or replace procedure update_products(
    v_id in products."Id"%TYPE,
    v_status in products.status%TYPE,
    v_code in products."Code"%Type,
    v_name in products."Name"%TYPE,
    v_updateDate in products."UpdateDate"%type,
    v_updateBy in products."UpdateBy"%type   
)
is
    v_count number;
begin
--check code
select count(*)into v_count from products
where products."Code" = v_code
    and "Id" <> v_id;
if v_count > 0 then
dbms_output.put_line('Tr�ng code');
return;
end if;

--update
    Update products
    set
    products.status = v_status,
    products."Name" = v_name,
    products."UpdateDate" = v_updateDate,
    products."UpdateBy" = v_updateBy
    where products."Id" = v_id;
    dbms_output.put_line('c?p nh?t th�nh c�ng');
    exception when others then
    dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
end update_products;

--sp delete product
create or replace procedure delete_products(
    v_id in products."Id"%type
)
is
begin

delete from products
where products."Id" = v_id;
dbms_output.put_line('X�a th�nh c�ng');
exception when others then
dbms_output.put_line('SQL: ' || SQLCODE || '' || SQLERRM);

end;

--sequence
create sequence product_insert_seq
    increment by 1
    start with 1
    maxvalue 10000
    nocache
    nocycle;
    
--log
create table product_audit(
log_id number generated as identity,
    product_id number,
    action varchar2(20),
    action_date date
);
--trigger
create or replace trigger product_noti_t
after insert or update or delete 
on products
for each row
begin
if inserting then
    Insert into product_audit(product_id, action, action_date)
    values (:NEW."Id", 'Insert', sysdate);
elsif updating then
    Insert into product_audit(product_id, action, action_date)
    values (:OLD."Id",'Update',sysdate);
elsif deleting then 
    insert into product_audit(product_id, action, action_date)
    values (:OLD."Id", 'Delete', sysdate);  
end if;
end;

-----------End Products--------------

-------------Buyer-------------------
select * from buyers
--sp insert buyer
create or replace procedure add_buyer(
    v_id in buyers."Id"%type,
    v_payment in buyers.payment_method%Type,
    v_code in buyers."Code"%Type,
    v_name in buyers."Name"%Type,
    v_createDate in buyers."CreateDate"%Type,

    v_createBy in buyers."CreateBy"%Type,

    v_offset in buyers."Offsets"%Type,
    v_partition in buyers."Partitions"%Type
)
is 
    v_count number;
begin

select count(*) into v_count from buyers
where buyers."Id" = v_id;
if v_count > 0 then
dbms_output.put_line('Tr�ng id');
return;
end if;

select  count(*) into v_count from buyers
where buyers."Code" = v_code;
if v_count > 0 then
dbms_output.put_line('Tr�ng code');
return;
end if;

insert into buyers("Id", payment_method, "Code", "Name" , "CreateDate", "UpdateDate", "CreateBy", "UpdateBy", "Offsets", "Partitions")
values (buyer_insert_seq.NEXTVAL,v_payment,v_code,v_name,v_createDate,null,v_createBy,null,v_offset,v_partition);
dbms_output.put_line('Th�m th�nh c�ng');
exception when others then
dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
end;

--sp update buyer
create or replace procedure update_buyer(
    v_id in buyers."Id"%type,
    v_payment in buyers.payment_method%type,
    v_name in buyers."Name"%type,
    v_updateDate in buyers."UpdateDate"%type,
    v_updateBy in buyers."UpdateBy"%type,
    v_code in buyers."Code"%type
)
is
    v_count number;
begin

    select count(*) into v_count from buyers
    where buyers."Code" = v_code;
    if v_count > 0 then
    dbms_output.put_line('Tr�ng code');
    return;
    end if;
update buyers
set
buyers."Name" = v_name,
buyers.payment_method = v_payment,
buyers."UpdateDate" = v_updateDate,
buyers."UpdateBy" = v_updateBy
where buyers."Id" = v_id;
    dbms_output.put_line('c?p nh?t th�nh c�ng');
    exception when others then
    dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
end update_buyer;

--sp delete buyer
create or replace procedure delete_buyer(
    v_id in buyers."Id"%type
)
is
begin

delete from buyers
where buyers."Id" = v_id;
dbms_output.put_line('X�a th�nh c�ng');
exception when others then
dbms_output.put_line('SQL: ' || SQLCODE || '' || SQLERRM);

end;

--sequence
create sequence buyer_insert_seq
    increment by 1
    start with 1
    maxvalue 10000
    nocache
    nocycle;
    
--log
create table buyer_audit(
log_id number generated as identity,
    buyer_id number,
    action varchar2(20),
    action_date date
);
--trigger
create or replace trigger buyer_noti_t
after insert or update or delete 
on buyers
for each row
begin
if inserting then
    Insert into buyer_audit(buyer_id, action, action_date)
    values (:NEW."Id", 'Insert', sysdate);
elsif updating then
    Insert into buyer_audit(buyer_id, action, action_date)
    values (:OLD."Id",'Update',sysdate);
elsif deleting then 
    insert into buyer_audit(buyer_id, action, action_date)
    values (:OLD."Id", 'Delete', sysdate);  
end if;
end;

-----------End Buyers--------------

------------Order-----------------
select * from orders
--sp insert order
create or replace procedure add_order(
    v_id in orders."Id"%type,
    v_status in orders.status%type,
    v_code in orders."Code"%type,
    v_name in orders."Name"%type,
    v_buyerId in orders.buyer_id%type,
    v_address in orders.address%type,
    v_createDate in orders."CreateDate"%type,
    v_createBy in orders."CreateBy"%type,
    v_offset in orders."Offsets"%type,
    v_partition in orders."Partitions"%type

)
is
    v_count number;
    v_buyer_count number;
begin
    select count(*) into v_count from orders
    where orders."Code" = v_code;
    if v_count > 0 then
    dbms_output.put_line('Tr�ng code');
    return;
    end if;
    
    select count(*) into v_buyer_count from buyers
    where buyers."Id" = v_buyerId;
    if v_buyer_count = 0 then 
    dbms_output.put_line('Ngu?i mua kh�ng t?n t?i');
    return;
    end if;
    
    insert into orders("Id", buyer_id, address, status, "Code", "Name" , "CreateDate", "UpdateDate", "CreateBy", "UpdateBy", "Offsets", "Partitions")
    values (order_insert_seq.NEXTVAL,v_buyerId,v_address,v_status,v_code,v_name,v_createDate,null,v_createBy,null,v_offset,v_partition);
    dbms_output.put_line('Th�m th�nh c�ng');
    exception when others then
    dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
    end;

--sp update order
create or replace procedure update_order(
    v_id in orders."Id"%type,

    v_address in orders.address%type,
    v_status in orders.status%type,
    v_name in orders."Name"%type,
    v_updateDate in orders."UpdateDate"%type,
    v_updateBy in orders."UpdateBy"%type
)  
is
    v_count number;
begin
    update orders
    set
    orders.address = v_address,
    orders.status = v_status,
    orders."Name" = v_name,
    orders."UpdateDate" = v_updateDate,
    orders."UpdateBy" = v_updateBy
    where orders."Id" = v_id;
    dbms_output.put_line('c?p nh?t th�nh c�ng');
    exception when others then
    dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
end update_order;

--sp delete order
create or replace procedure delete_order(
    v_id in orders."Id"%type
)
is
begin

delete from orders
where orders."Id" = v_id;
dbms_output.put_line('X�a th�nh c�ng');
exception when others then
dbms_output.put_line('SQL: ' || SQLCODE || '' || SQLERRM);

end;

--sequence
create sequence order_insert_seq
    increment by 1
    start with 1
    maxvalue 10000
    nocache
    nocycle;
    
--log
create table order_audit(
log_id number generated as identity,
    order_id number,
    action varchar2(20),
    action_date date
);
--trigger
create or replace trigger order_noti_t
after insert or update or delete 
on orders
for each row
begin
if inserting then
    Insert into order_audit(order_id, action, action_date)
    values (:NEW."Id", 'Insert', sysdate);
elsif updating then
    Insert into order_audit(order_id, action, action_date)
    values (:OLD."Id",'Update',sysdate);
elsif deleting then 
    insert into order_audit(order_id, action, action_date)
    values (:OLD."Id", 'Delete', sysdate);  
end if;
end;
------------End Order-----------------

------------Order Item--------------
select * from order_items

--sp insert orderitem
create or replace procedure add_orderItem(
    v_id in order_items."Id"%type,
    v_unit in order_items.units%type,
    v_unitPrice in order_items.unit_price%type,
    v_productId in order_items.product_id%type,
    v_orderId in order_items.order_id%type,
    v_code in order_items."Code"%type,
    v_name in order_items."Name"%type,
    v_createDate in order_items."CreateDate"%type,
    v_createBy in order_items."CreateBy"%type,
    v_offset in order_items."Offsets"%type,
    v_partition in order_items."Partitions"%type
)
is
    v_count number;
    v_product_count number;
    v_order_count number;
begin
    select count(*) into v_count from order_items
    where order_items."Code" = v_code;
    if v_count > 0 then
    dbms_output.put_line('Code d� t?n t?i');
    return;
    end if;
    
    select count(*) into v_product_count from products
    where products."Id" = v_productId;
    if v_product_count = 0 then
    dbms_output.put_line('Kh�ng c� Product t?n t?i');
    return;
    end if;
    
    select count(*) into v_order_count from orders
    where orders."Id" = v_orderId;
    if v_order_count = 0 then
    dbms_output.put_line('Kh�ng c� Order t?n t?i');
    return;
    end if;
    
    insert into order_items("Id", units, unit_price, product_id, order_id, "Code", "Name" , "CreateDate", "UpdateDate", "CreateBy", "UpdateBy", "Offsets", "Partitions")
    values (orderItems_insert_seq.NEXTVAL,v_unit,v_unitPrice,v_productId,v_orderId,v_code,v_name,v_createDate,null,v_createBy,null,v_offset,v_partition);
    dbms_output.put_line('Th�m th�nh c�ng');
    exception when others then
    dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
    end;

--sp update orderItem
create or replace procedure update_orderItem(
    v_id in order_items."Id"%type,
    v_unit in order_items.units%type,
    v_unitPrice in order_items.unit_price%type,
    v_productId in order_items.product_id%type,

    v_name in order_items."Name"%type,
    v_updateDate in order_items."UpdateDate"%type,
    v_updateBy in order_items."UpdateBy"%type
)
is
    v_product_count number;
begin
    select count(*) into v_product_count from products
    where products."Id" = v_productId;
    if v_product_count = 0 then 
    dbms_output.put_line('Kh�ng c� Product t?n t?i');
    return;
    end if;
    
    update order_items
    set
    order_items.units = v_unit,
    order_items.unit_price = v_unitPrice,
    order_items."Name" = v_name,
    order_items."UpdateDate" = v_updateDate,
    order_items."UpdateBy" = v_updateBy,
    order_items.product_id = v_productId
    where order_items."Id" = v_id;
    dbms_output.put_line('c?p nh?t th�nh c�ng');
    exception when others then
    dbms_output.put_line('L?i: ' || SQLCODE || ' - ' || SQLERRM);
end update_orderItem;

--sp delete orderItem
create or replace procedure delete_orderItem(
    v_id in order_items."Id"%type
)
is
begin
    delete from order_items
    where order_items."Id" = v_id;
    dbms_output.put_line('X�a th�nh c�ng');
    exception when others then
    dbms_output.put_line('SQL: ' || SQLCODE || '' || SQLERRM);

end;
--sequence
create sequence orderItems_insert_seq
start with 1
increment by 1
nocache
nocycle;

--log
create table orderItem_audit(
log_id number generated as identity,
    orderItem_id number,
    action varchar2(20),
    action_date date
);
--trigger
create or replace trigger orderItem_noti_t
after insert or update or delete 
on order_items
for each row
begin
if inserting then
    Insert into orderItem_audit(orderItem_id, action, action_date)
    values (:NEW."Id", 'Insert', sysdate);
elsif updating then
    Insert into orderItem_audit(orderItem_id, action, action_date)
    values (:OLD."Id",'Update',sysdate);
elsif deleting then 
    insert into orderItem_audit(orderItem_id, action, action_date)
    values (:OLD."Id", 'Delete', sysdate);  
end if;
end;
-----------End Order Item-------------
savepoint a