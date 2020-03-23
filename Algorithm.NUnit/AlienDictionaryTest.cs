using NUnit.Framework;
using System;
namespace Algorithm.NUnit
{
    [TestFixture()]
    public class AlienDictionaryTest
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(string[] words, string expected)
        {
            // Arrange
            var obj = new Facebook.AlienDictionary();

            // Act
            var result = obj.AlienOrder(words);

            // Assert
            Assert.AreEqual(expected, result);
        }


        static object[] TestCases =
        {
            new object[] {new []{ "wrt", "wrf", "er", "ett", "rftt" }, "wertf" },
            new object[] {new []{ "z", "z"}, "z" },
            new object[] {new []{ "zy", "zx"}, "yxz" },
            new object[] {new []{"ab","adc"}, "cbda" },
            new object[] {new []{ "wrt", "wrtkj" }, "jktrw" },
            new object[] {new []{ "z", "x", "z" }, "" },
            new object[] {new []{ "a", "b", "ca", "cc" }, "abc" },
            /*
             * a
             * b
             * ca
             * cc
             *
             * a->b->c
             */
            new object[] {new []{ "ac", "ab", "b" }, "cab" },
            /*
             * ac
             * ab
             * b
             *
             * a->b
             * c/
             */
            new object[] {new []{ "ri", "xz", "qxf", "jhsguaw", "dztqrbwbm", "dhdqfb", "jdv", "fcgfsilnb", "ooby" }, "" },
            /*
             * ri
             * xz
             * qxf
             * jhsguaw
             * dztqrbwbm
             * dhdqfb
             * jdv
             * fcgfsilnb
             * ooby
             *
             * d->j->d
             * j<-d
             * 
             * r->x->q->j->d->j->f->o
             *
             * x<-r
             * q<-x
             * j<-q
             * d<-j
             * j<-d  // cycle
             * f<-j
             */
            new object[] {new []{ "bsusz", "rhn", "gfbrwec", "kuw", "qvpxbexnhx", "gnp", "laxutz", "qzxccww" }, "" },
            /*
             * bsusz
             * rhn
             * gfbrwec
             * kuw
             * qvpxbexnhx
             * gnp
             * laxutz
             * qzxccww
             *
             * b->r->g->k->q->g->l->q
             * r<-b
             * g<-r
             * k<-g
             * q<-k
             * g<-q
             * l<-g
             * q<-l *cycle
             */
             new object[] {new []{ "dvpzu", "bq", "lwp", "akiljwjdu", "vnkauhh", "ogjgdsfk", "tnkmxnj", "uvwa", "zfe", "dvgghw", "yeyruhev", "xymbbvo", "m", "n" }, "" },
             /*
              * dvpzu
              * bq
              * lwp
              * akiljwjdu
              * vnkauhh
              * ogjgdsfk
              * tnkmxnj
              * uvwa
              * zfe
              * dvgghw
              * yeyruhev
              * xymbbvo
              * m
              * n
              *
              * d->b->l->a->v->o->t->u->z->d->y // cycle
              * b<-d
              * l<-b
              * a<-l
              * v<-a
              * o<-v
              * t<-o
              * u<-t
              * d<-z
              * y<-d // cycle
              */
              new object[] {new []{ "hcgftu", "oatzksylro", "hkbfwpcbo", "hx" }, "" }
              /*
               * hcgftu
               * oatzksylro
               * hkbfwpcbo
               * hx
               *
               * h->o->h
               * c->a->k->x
               * g->t->b
               */
    };
    }
}
