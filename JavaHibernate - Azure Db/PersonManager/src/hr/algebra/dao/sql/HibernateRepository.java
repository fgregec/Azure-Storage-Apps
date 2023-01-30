/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.dao.sql;

import hr.algebra.dao.Repository;
import hr.algebra.model.Person;
import hr.algebra.model.Subject;
import java.util.List;
import javafx.scene.control.Alert;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.ButtonType;
import javax.persistence.EntityManager;

public class HibernateRepository implements Repository {

   @Override
    public int addPerson(Person data) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // in order to use in in transaction scope, we must create new Person that with data details
            Person person = new Person(data);
            em.persist(person);
            em.getTransaction().commit();
            return person.getIDPerson();
        }
    }

    @Override
    public void deletePerson(Person person) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // person comes from earlier transaction, so we must merge it into this one
            em.remove(em.contains(person) ? person : em.merge(person));
            em.getTransaction().commit();
        }
    }

    @Override
    public List<Person> getPeople() throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            return entityManager.get().createNamedQuery(HibernateFactory.SELECT_PEOPLE).getResultList();
        }
    }

    @Override
    public Person getPerson(int idPerson) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            return em.find(Person.class, idPerson);
        }
    }

    @Override
    public void updatePerson(Person person) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // automatically persists
            em.find(Person.class, person.getIDPerson()).updateDetails(person);
            em.getTransaction().commit();            
        }
    }

    @Override
    public void release() {
        HibernateFactory.release();
    }

    @Override
    public List<Subject> getSubjects() throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            return entityManager.get().createNamedQuery(HibernateFactory.SELECT_SUBJECT).getResultList();
        }    }

    @Override
    public int addSubject(Subject data) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // in order to use in in transaction scope, we must create new Person that with data details
            Subject subject = new Subject(data);
            em.persist(subject);
            em.getTransaction().commit();
            return subject.getIDSubject();
        }
    }

    @Override
    public void deleteSubject(Subject subject) throws Exception {
         try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // person comes from earlier transaction, so we must merge it into this one
            em.remove(em.contains(subject) ? subject : em.merge(subject));
            em.getTransaction().commit();
        }
    }

    @Override
    public Subject getSubject(int idSubject) throws Exception {
       try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            return em.find(Subject.class, idSubject);
        }
    }

    @Override
    public void updateSubject(Subject subject) throws Exception {
        try (EntityManagerWrapper entityManager = HibernateFactory.getEntityManager()) {
            EntityManager em = entityManager.get();
            em.getTransaction().begin();
            // automatically persists
            em.find(Subject.class, subject.getIDSubject()).updateDetails(subject);
            em.getTransaction().commit();            
        }    }

}
