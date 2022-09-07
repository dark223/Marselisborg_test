-- Table: public.familie

-- DROP TABLE IF EXISTS public.familie;

CREATE TABLE IF NOT EXISTS public.familie
(
    id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT familie_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.familie
    OWNER to postgres;