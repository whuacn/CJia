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
  is '������';
-- Add comments to the columns 
comment on column GM_PARAMETER.VALUE
  is '����ֵ';
comment on column GM_PARAMETER.VALUE_TYPE
  is '��������';
comment on column GM_PARAMETER.VALUE_DESC
  is '����';
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
values (1, '123456', 'PDF_Password', 'PDF���ܵ�����');
insert into gm_parameter (ID, VALUE, VALUE_TYPE, VALUE_DESC)
values (2, '����ҽѧԺ����ҽԺ', 'LogoContent', 'ˮӡ����');
insert into gm_parameter (ID, VALUE, VALUE_TYPE, VALUE_DESC)
values (3, '50', 'LogoInclination', 'ˮӡ��б��');

-- Create table
create table GM_FAVORITES
(
  FAVORITES_ID   VARCHAR2(10) not null,
  USER_ID        VARCHAR2(10),
  FAVORITES_NAME VARCHAR2(100),
  CREATE_BY      VARCHAR2(20),
  CREATE_DATE    DATE default SYSDATE,
  UPDATE_BY      VARCHAR2(20),
  UPDATE_DATE    DATE,
  STATUS         CHAR(1) default 1
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
comment on table GM_FAVORITES
  is '�ղؼ�';
-- Add comments to the columns 
comment on column GM_FAVORITES.CREATE_BY
  is '������';
comment on column GM_FAVORITES.CREATE_DATE
  is '��������';
comment on column GM_FAVORITES.UPDATE_BY
  is '�޸���';
comment on column GM_FAVORITES.UPDATE_DATE
  is '�޸�����';
comment on column GM_FAVORITES.STATUS
  is '״̬';
-- Create/Recreate primary, unique and foreign key constraints 
alter table GM_FAVORITES
  add constraint FAVORITES_ID primary key (FAVORITES_ID)
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
-- Create/Recreate indexes 
create index F_FAVORITES_NAME on GM_FAVORITES (FAVORITES_NAME)
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
create index F_USER_ID on GM_FAVORITES (USER_ID)
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
  -- Create table
create table GM_FAVORITES_DETAIL
(
  ID             VARCHAR2(10) not null,
  FAVORITES_ID   VARCHAR2(10),
  HEALTH_ID      VARCHAR2(50),
  FAVORITES_DATE DATE default sysdate,
  CREATE_BY      VARCHAR2(20),
  CREATE_DATE    DATE default SYSDATE,
  UPDATE_BY      VARCHAR2(20),
  UPDATE_DATE    DATE,
  STATUS         CHAR(1) default 1
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
comment on table GM_FAVORITES_DETAIL
  is '�ղؼ�����';
-- Add comments to the columns 
comment on column GM_FAVORITES_DETAIL.FAVORITES_ID
  is '�ղؼ�id';
comment on column GM_FAVORITES_DETAIL.HEALTH_ID
  is '����ID';
comment on column GM_FAVORITES_DETAIL.FAVORITES_DATE
  is '�ղ�ʱ��';
comment on column GM_FAVORITES_DETAIL.CREATE_BY
  is '������';
comment on column GM_FAVORITES_DETAIL.CREATE_DATE
  is '��������';
comment on column GM_FAVORITES_DETAIL.UPDATE_BY
  is '�޸���';
comment on column GM_FAVORITES_DETAIL.UPDATE_DATE
  is '�޸�����';
comment on column GM_FAVORITES_DETAIL.STATUS
  is '״̬';
-- Create/Recreate primary, unique and foreign key constraints 
alter table GM_FAVORITES_DETAIL
  add constraint FF_ID primary key (ID)
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
-- Create/Recreate indexes 
create index FF_FAVORITES_ID on GM_FAVORITES_DETAIL (FAVORITES_ID)
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
-- Create sequence 
create sequence GM_FAVORITES_SEQ
minvalue 1000000000
maxvalue 9999999999
start with 1000000001
increment by 1
cache 20;
-- Create sequence 
create sequence GM_FAVORITES_DETAIL_SEQ
minvalue 1000000000
maxvalue 9999999999
start with 1000000001
increment by 1
cache 20;

ALTER TABLE GM_PROJECT ADD IS_LOOK CHAR(1) default 1;

ALTER TABLE ST_PICTURE ADD IS_LOOK CHAR(1) default 1;

insert into tm_function (FUNCTION_ID, FUNCTION_NAME, USER_TYPE, STATUS, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE)
values (1000010001, '���Ȩ��', '305', '1', 1000000081, to_date('16-05-2015 16:20:47', 'dd-mm-yyyy hh24:mi:ss'), null, null);

insert into tm_function (FUNCTION_ID, FUNCTION_NAME, USER_TYPE, STATUS, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE)
values (1000010002, 'ˮӡ����', '305', '1', 1000000081, to_date('16-05-2015 16:21:13', 'dd-mm-yyyy hh24:mi:ss'), null, null);

-- Create table 2015-5-26
create table GM_TRACE
(
  trace_code    VARCHAR2(50),
  trace_type    VARCHAR2(100),
  trace_context VARCHAR2(200),
  trace_date    DATE
)
tablespace DATA01
  pctfree 10
  initrans 1
  maxtrans 255;
-- Create/Recreate indexes 
create index IDX_TRACE_DATE on GM_TRACE (TRACE_DATE)
  tablespace DATA01
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );