// 290. Word Problem
// Tags: hash table, bijection, hash set
//

impl Solution {
    pub fn word_pattern(pattern: String, s: String) -> bool {
        use std::collections::{HashMap, HashSet, hash_map::Entry};
        
        let mut dict = HashMap::<char, &str>::new();
        // This set will ensure 1-to-1 correspondence w/ elements in pattern and s.
        let mut bijection_set = HashSet::<&str>::new();
        
        // Edge case.
        if s.split_whitespace().count() != pattern.chars().count() {
            return false;
        }

        let mut words_iter = s.split_whitespace();
        let mut chars_iter = pattern.chars();

        while let Some(w) = words_iter.next() {
            if let Some(c) = chars_iter.next() {
                match dict.entry(c) {
                    Entry::Occupied(c1) => {
                        if c1.get() != &w { 
                            return false; 
                        }
                    },
                    Entry::Vacant(c2) => {
                        if !bijection_set.contains(w) {
                            bijection_set.insert(w);
                            c2.insert(w);
                        } 
                        // We do not have a 1-to-1 mapping, therefore we are done.
                        else {
                            return false;
                        }
                    },
                }
            }
        }

        true
    }
}