-- Table: public.opholdssted

-- DROP TABLE IF EXISTS public.opholdssted;

CREATE TABLE IF NOT EXISTS public.opholdssted
(
    opholdssted_id integer NOT NULL DEFAULT nextval('opholdssted_opholdssted_id_seq'::regclass),
    navn character varying(50) COLLATE pg_catalog."default" NOT NULL,
    by character varying(50) COLLATE pg_catalog."default",
    CONSTRAINT opholdssted_pkey PRIMARY KEY (opholdssted_id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.opholdssted
    OWNER to postgres;