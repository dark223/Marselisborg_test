-- Table: public.flygtning

-- DROP TABLE IF EXISTS public.flygtning;

CREATE TABLE IF NOT EXISTS public.flygtning
(
    flygtning_id integer NOT NULL DEFAULT nextval('flygtning_flygtning_id_seq'::regclass),
    navn character varying(50) COLLATE pg_catalog."default" NOT NULL,
    alder integer,
    center integer NOT NULL DEFAULT 0,
    familieid integer,
    CONSTRAINT flygtning_pkey PRIMARY KEY (flygtning_id),
    CONSTRAINT "Opholdssted_FK" FOREIGN KEY (center)
        REFERENCES public.opholdssted (opholdssted_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT familie FOREIGN KEY (familieid)
        REFERENCES public.familie (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.flygtning
    OWNER to postgres;
-- Index: fki_Opholdssted_FK

-- DROP INDEX IF EXISTS public."fki_Opholdssted_FK";

CREATE INDEX IF NOT EXISTS "fki_Opholdssted_FK"
    ON public.flygtning USING btree
    (center ASC NULLS LAST)
    TABLESPACE pg_default;
-- Index: fki_familie

-- DROP INDEX IF EXISTS public.fki_familie;

CREATE INDEX IF NOT EXISTS fki_familie
    ON public.flygtning USING btree
    (familieid ASC NULLS LAST)
    TABLESPACE pg_default;