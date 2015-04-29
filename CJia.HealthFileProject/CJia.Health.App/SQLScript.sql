-- Create table
create table GM_PARAMETER
(
  ID         NUMBER(10) not null,
  VALUE      VARCHAR2(100),
  VALUE_TYPE VARCHAR2(100),
  VALUE_DESC VARCHAR2(200)
)
tablespace USERS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table GM_PARAMETER
  is '参数表';
-- Add comments to the columns 
comment on column GM_PARAMETER.VALUE
  is '参数值';
comment on column GM_PARAMETER.VALUE_TYPE
  is '参数类型';
comment on column GM_PARAMETER.VALUE_DESC
  is '描述';
-- Create/Recreate primary, unique and foreign key constraints 
alter table GM_PARAMETER
  add constraint P_ID primary key (ID)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table GM_PARAMETER
  add constraint P_TYPE unique (VALUE_TYPE)
  using index 
  tablespace USERS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );

insert into gm_parameter (ID, VALUE, VALUE_TYPE, VALUE_DESC)
values (1, '123456', 'PDF_Password', 'PDF加密的密码');
