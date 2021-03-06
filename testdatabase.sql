PGDMP     $                    y            testdatabase    14.1    14.1     ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16394    testdatabase    DATABASE     p   CREATE DATABASE testdatabase WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'English_United States.1252';
    DROP DATABASE testdatabase;
                postgres    false            ?            1259    16396 
   department    TABLE     q   CREATE TABLE public.department (
    departmentid integer NOT NULL,
    departmentname character varying(500)
);
    DROP TABLE public.department;
       public         heap    postgres    false            ?            1259    16395    department_departmentid_seq    SEQUENCE     ?   CREATE SEQUENCE public.department_departmentid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public.department_departmentid_seq;
       public          postgres    false    210            ?           0    0    department_departmentid_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public.department_departmentid_seq OWNED BY public.department.departmentid;
          public          postgres    false    209            ?            1259    16401    employee    TABLE     ?   CREATE TABLE public.employee (
    employeeid integer NOT NULL,
    employeename character varying(500),
    department character varying(500),
    dateofjoining date,
    photofilename character varying(500)
);
    DROP TABLE public.employee;
       public         heap    postgres    false            ?            1259    16400    employee_employeeid_seq    SEQUENCE     ?   CREATE SEQUENCE public.employee_employeeid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.employee_employeeid_seq;
       public          postgres    false    212            ?           0    0    employee_employeeid_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.employee_employeeid_seq OWNED BY public.employee.employeeid;
          public          postgres    false    211            a           2604    16399    department departmentid    DEFAULT     ?   ALTER TABLE ONLY public.department ALTER COLUMN departmentid SET DEFAULT nextval('public.department_departmentid_seq'::regclass);
 F   ALTER TABLE public.department ALTER COLUMN departmentid DROP DEFAULT;
       public          postgres    false    209    210    210            b           2604    16404    employee employeeid    DEFAULT     z   ALTER TABLE ONLY public.employee ALTER COLUMN employeeid SET DEFAULT nextval('public.employee_employeeid_seq'::regclass);
 B   ALTER TABLE public.employee ALTER COLUMN employeeid DROP DEFAULT;
       public          postgres    false    212    211    212            ?          0    16396 
   department 
   TABLE DATA           B   COPY public.department (departmentid, departmentname) FROM stdin;
    public          postgres    false    210   ?       ?          0    16401    employee 
   TABLE DATA           f   COPY public.employee (employeeid, employeename, department, dateofjoining, photofilename) FROM stdin;
    public          postgres    false    212          ?           0    0    department_departmentid_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.department_departmentid_seq', 3, true);
          public          postgres    false    209            ?           0    0    employee_employeeid_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.employee_employeeid_seq', 1, true);
          public          postgres    false    211            ?      x?3???2?.-(?/*?????? 3??      ?   '   x?3?t?O???4202?50"?Ĥd???t?=... |8:     