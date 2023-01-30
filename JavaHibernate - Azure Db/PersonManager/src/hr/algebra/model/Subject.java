/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra.model;

import hr.algebra.dao.sql.HibernateFactory;
import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Komp
 */

@Entity
@Table(name = "Subject")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = HibernateFactory.SELECT_SUBJECT, query = "SELECT s FROM Subject s")
})


public class Subject implements Serializable{
    
    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "IDSubject")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer IDSubject;
    
    @Basic(optional = false)
    @Column(name = "Name")
    private String name;
    
    public Subject(){}
    
    public Subject(Subject data){
        updateDetails(data);
    }

    public Subject(Integer IDSubject){
        this.IDSubject = IDSubject;
    }
    
    public Subject(Integer IDSubject, String name){
        this.IDSubject = IDSubject;
        this.name = name;
    }
    
    public Integer getIDSubject() {
        return IDSubject;
    }

    public void setIDSubject(Integer IDSubject) {
        this.IDSubject = IDSubject;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    
    
    public void updateDetails(Subject data) {
        this.name = data.getName();
    }

    @Override
    public String toString() {
        return IDSubject + " " + name;
    }
    
    
    
}
